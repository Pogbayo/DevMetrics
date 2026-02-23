using DevMetrics.Domain.Entities;

namespace DevMetrics.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid userId);

        Task<List<User>> GetAllUsersAsync();

        Task<List<Guid>> GetUsersByProjectAsync(long projectId);

        Task<int> GetTotalUserCountAsync();

        Task<Dictionary<Guid, int>> GetUserProjectCountAsync(Guid userId);

        Task<List<string>> GetUsersWithNoProjectsAsync();
    }
}
