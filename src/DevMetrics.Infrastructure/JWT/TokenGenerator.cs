using DevMetrics.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DevMetrics.Domain.Entities;
using System.Security.Claims;
using System.Text;
namespace DevMetrics.Infrastructure.JWT
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly JwtSetting _jwtSettings;
        private readonly ILogger<TokenGenerator> _logger;

        public TokenGenerator(IOptions<JwtSetting> jwtOptions, ILogger<TokenGenerator> logger)
        {
            _jwtSettings = jwtOptions.Value;
            _logger = logger;
        }


        public async Task<string> GenerateAccessToken(User user)
        {
            await  Task.Yield(); 
            if (user == null)
            {
                _logger.LogWarning("User object is null");
                throw new ArgumentNullException(nameof(user));
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            };

            var expiryMinutes = _jwtSettings.ExpireHours * 60;

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Key)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
