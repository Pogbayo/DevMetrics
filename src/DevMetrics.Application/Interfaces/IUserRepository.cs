using DevMetrics.Domain.Entities;

namespace DevMetrics.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid userId);

        Task<List<User>> GetAllUsersAsync();

        Task<List<User>> GetUsersByProjectAsync(Guid projectId);

        Task<int> GetTotalUserCountAsync();

        Task<Dictionary<Guid, int>> GetUserProjectCountAsync();

        Task<List<User>> GetUsersWithNoProjectsAsync();
    }
}
