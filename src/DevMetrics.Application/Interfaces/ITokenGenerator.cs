

using DevMetrics.Domain.Entities;

namespace DevMetrics.Application.Interfaces
{
    public interface ITokenGenerator
    {
        Task<string> GenerateAccessToken(User user);
    }
}
