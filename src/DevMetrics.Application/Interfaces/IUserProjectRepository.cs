using DevMetrics.Domain.Entities;

namespace DevMetrics.Application.Interfaces
{
    public interface IUserProjectRepository
    {
        Task AddUserToProjectAsync(Guid userId, Guid projectId);

        Task RemoveUserFromProjectAsync(Guid userId, Guid projectId);

        Task<List<UserProject>> GetAllRelationsAsync();

        Task<List<UserProject>> GetByUserIdAsync(Guid userId);

        Task<List<UserProject>> GetByProjectIdAsync(Guid projectId);

        Task<bool> ExistsAsync(Guid userId, Guid projectId);
    }
}

