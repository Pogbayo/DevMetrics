using DevMetrics.Domain.Entities;

namespace DevMetrics.Application.Interfaces
{
    public interface IProjectRepository
    {
        Task AddProjectAsync(Project project);

        Task<Project?> GetProjectByIdAsync(Guid projectId);

        Task<List<Project>> GetAllProjectsAsync();

        Task<List<Project>> GetProjectsByUserAsync(Guid userId);

        Task<int> GetTotalProjectCountAsync();

        Task<Dictionary<Guid, int>> GetProjectUserCountAsync();

        Task<List<Project>> GetProjectsWithNoUsersAsync();
    }
}
