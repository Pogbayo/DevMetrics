using DevMetrics.Application.Interfaces;
using DevMetrics.Domain.Entities;
using DevMetrics.Infrastructure.Shard;

namespace DevMetrics.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShardedDbContextFactory _factory;
        private readonly ICurrentUserService _currentUser;

        public UserRepository(ShardedDbContextFactory factory, ICurrentUserService currentUser)
        {
            _factory = factory;
            _currentUser = currentUser;
        }

        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalUserCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<Guid, int>> GetUserProjectCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersByProjectAsync(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersWithNoProjectsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
