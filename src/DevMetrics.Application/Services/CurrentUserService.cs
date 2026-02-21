using DevMetrics.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DevMetrics.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? UserId =>
            _httpContextAccessor.HttpContext?.Items["UserId"] as Guid?;

        public string? Username =>
            _httpContextAccessor.HttpContext?.Items["Username"] as string;
    }
}
