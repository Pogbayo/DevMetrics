using DevMetrics.Application.Interfaces;
using DevMetrics.Domain.Entities;
using DevMetrics.Infrastructure.Data;
using DevMetrics.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DevMetrics.Infrastructure.Repositories
{

    public class AuthRepository : IAuthRepository
    {
        private readonly AuthDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;
        public AuthRepository(
               ITokenGenerator tokenGenerator,
               AuthDbContext context,
               ICurrentUserService currentUser)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
            _currentUser = currentUser;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return null;

            bool isValid = PasswordHasher.VerifyPassword(password, user.PasswordHash);

            if (!isValid)
                return null;

            return await _tokenGenerator.GenerateAccessToken(user);
        }

        public async Task RegisterAsync(string email, string password, string username)
        {
            string hashedPassword = PasswordHasher.HashPassword(password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Email = email,
                PasswordHash = hashedPassword
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

    }
}
