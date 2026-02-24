using DevMetrics.Application.DTOs;
using DevMetrics.Application.Interfaces;
using DevMetrics.Domain.Entities;
using DevMetrics.Infrastructure.Data;
using DevMetrics.Infrastructure.Shard;
using Microsoft.EntityFrameworkCore;

namespace DevMetrics.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ShardedDbContextFactory _factory;
        private readonly ICurrentUserService _currentUser;
        private readonly AuthDbContext _context;
        private readonly CentralDbContext _centralDbContext;
        public ProjectRepository(ShardedDbContextFactory factory, ICurrentUserService currentUser, AuthDbContext context, CentralDbContext centralDbContext)
        {
            _factory = factory;
            _currentUser = currentUser;
            _context = context;
            _centralDbContext = centralDbContext;
        }
        public async Task AddProjectAsync(Project project)
        {
            if (!_currentUser.UserId.HasValue)
                throw new InvalidOperationException("Current user ID is not set.");

            var context = _factory.Create(_currentUser.UserId.Value);
            await context.Projects.AddAsync(project);
            await context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<Project>> GetAllProjectsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var allProjects = new List<Project>();

            for (int shard = 0; shard < 3; shard++)
            {
                using var ctx = _factory.CreateForShard(shard);
                var projects = await ctx.Projects
                    .AsNoTracking()
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();

                allProjects.AddRange(projects);
            }

            allProjects = allProjects.GroupBy(p => p.Id).Select(g => g.First()).ToList();

            var total = allProjects.Count;
            var paged = allProjects.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedResult<Project>
            {
                Items = paged,
                TotalCount = total,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(total / (double)pageSize),
            };
        }

        public async Task<Project?> GetProjectByIdAsync(long projectId)
        {
            var userId = await  _centralDbContext.UserProjects
                .Where(up=> up.ProjectId == projectId)  
                .Select(up => up.UserId)
                .FirstOrDefaultAsync();

           using var shardContext = _factory.Create(userId);
            return await shardContext.Projects.FindAsync(projectId); 
        }

        public Task<List<Project>> GetProjectsByUserAsync(Guid userId)
        {
           using var shardContext = _factory.Create(userId);
            return shardContext.Projects
                .Where(p => p.UserProjects.Any(up => up.UserId == userId))
                .ToListAsync(); 
        }


        public async Task<int> GetTotalProjectCountAsync(int shardNumber)
        {
            var context =  _factory.CreateForShard(shardNumber);
            return await context.Projects.CountAsync(); 
        }

        public async Task<PaginatedResult<Project>> GetAllProjectsByShardAsync(
            int shardNumber,
            int pageNumber = 1,
            int pageSize = 10)
        {
            if (shardNumber < 0 || shardNumber >= 3)
                throw new ArgumentOutOfRangeException(nameof(shardNumber), "Shard number must be 0, 1, or 2");

            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            using var ctx = _factory.CreateForShard(shardNumber);

            var baseQuery = ctx.Projects
                .AsNoTracking()
                .OrderByDescending(p => p.Id); 

            var totalCount = await baseQuery.CountAsync();

            var pagedItems = await baseQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<Project>
            {
                Items = pagedItems,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
            };
        }
    }
}
