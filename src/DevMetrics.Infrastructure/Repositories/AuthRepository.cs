using Microsoft.AspNetCore.Identity;
using DevMetrics.Application.Interfaces;
using DevMetrics.Domain.Entities;
using DevMetrics.Infrastructure.Shard;

namespace DevMetrics.Infrastructure.Repositories
{

    public class AuthRepository
    {
        private readonly ShardedDbContextFactory _factory;
        private readonly ICurrentUserService _currentUser;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthRepository(
               ShardedDbContextFactory factory,
               ICurrentUserService currentUser)
        {
            _factory = factory;
            _currentUser = currentUser;
            _passwordHasher = new PasswordHasher<User>();
        }
    }
}
