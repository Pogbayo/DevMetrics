using DevMetrics.Application.DTOs;
using DevMetrics.Domain.Entities;

namespace DevMetrics.Application.Interfaces
{
    public interface IProjectRepository
    {
        Task AddProjectAsync(Project project);

        Task<Project?> GetProjectByIdAsync(long projectId);

        Task<PaginatedResult<Project>> GetAllProjectsAsync(int pageNumber = 1, int pageSize = 10);
        Task<List<Project>> GetProjectsByUserAsync(Guid userId);

        Task<int> GetTotalProjectCountAsync(int shardNumber);

        Task<PaginatedResult<Project>> GetAllProjectsByShardAsync(
            int shardNumber,
            int pageNumber = 1,
            int pageSize = 10);


    }
}
