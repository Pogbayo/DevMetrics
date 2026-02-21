using DevMetrics.Application.Interfaces;
using DevMetrics.Domain.Entities;
using DevMetrics.Infrastructure.Shard;

namespace DevMetrics.Infrastructure.Repositories
{
    public class UserProjectRepository : IUserProjectRepository
    {
        private readonly ShardedDbContextFactory _factory;

        public UserProjectRepository(ShardedDbContextFactory factory)
        {
            _factory = factory;
        }

        public Task AddUserToProjectAsync(Guid userId, Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid userId, Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserProject>> GetAllRelationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserProject>> GetByProjectIdAsync(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserProject>> GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserFromProjectAsync(Guid userId, Guid projectId)
        {
            throw new NotImplementedException();
        }
    }
}
