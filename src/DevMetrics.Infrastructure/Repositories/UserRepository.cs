using DevMetrics.Application.Repositories;
using DevMetrics.Domain.Entities;
using DevMetrics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevMetrics.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevMetricsDbContext _db;

        public UserRepository(DevMetricsDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(long id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception();
            }
            return user;
        }
      
    }
}
