

using DevMetrics.Domain.Entities;

namespace DevMetrics.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<string?> LoginAsync(string email, string password);
        Task RegisterAsync(User user);

    }
}
