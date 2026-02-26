using DevMetrics.Application.Interfaces;
using DevMetrics.Domain.Entities;
using DevMetrics.Infrastructure.Data;
using DevMetrics.Infrastructure.Shard;
using Microsoft.EntityFrameworkCore;

namespace DevMetrics.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShardedDbContextFactory _factory;
        private readonly ICurrentUserService _currentUser;
        private readonly AuthDbContext _context;
        private readonly CentralDbContext _centralDbContext;
        public UserRepository(ShardedDbContextFactory factory,CentralDbContext centralDbContext, AuthDbContext context, ICurrentUserService currentUser)
        {
            _centralDbContext = centralDbContext;
            _context = context;
            _factory = factory;
            _currentUser = currentUser;
        }

        private DevMetricsDbContext CreateContext()
        {
            var userId = _currentUser.UserId;

                if (!userId.HasValue || userId.Value == Guid.Empty)
                throw new UnauthorizedAccessException("User ID not found.");

            return _factory.Create(userId.Value);
        }


        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users ?? new List<User>();
        }


        public async Task<int> GetTotalUserCountAsync()
        {
           return await _context.Users.CountAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId); 
        }

        public async Task<Dictionary<Guid, int>> GetUserProjectCountAsync(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId);
            if (user == null)
            {
                return new Dictionary<Guid, int>();
            }
            return new Dictionary<Guid, int> { { user.Id, user.ProjectCount } };
        }

        public async Task<List<Guid>> GetUsersByProjectAsync(long projectId)
        {
            var userIds = await _centralDbContext.UserProjects
                .Where(up => up.ProjectId == projectId)
                .Select(up => up.UserId)
                .ToListAsync();

            if (userIds.Count == 0)
                new List<Guid>();
            
            return userIds;
        }

        public async Task<List<string>> GetUsersWithNoProjectsAsync()
        {
            var users = await _context.Users
                .Where(up => up.ProjectCount == 0)
                .Select(up => up.Username)
                .ToListAsync();

            return users;
        }
    }
}
