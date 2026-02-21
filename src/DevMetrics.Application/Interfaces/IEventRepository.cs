using DevMetrics.Domain.Entities;

namespace DevMetrics.Application.Interfaces
{
    public interface IEventRepository
    {
        Task AddEventAsync(Event ev);

        Task<List<Event>> GetAllEventsAsync();

        Task<List<Event>> GetEventsByUserAsync(Guid userId);

        Task<List<Event>> GetEventsByTypeAsync(string type);

        Task<int> GetTotalEventCountAsync();

        Task<int> GetEventCountByUserAsync(Guid userId);

        Task<int> GetEventCountByTypeAsync(string type);

        Task<Dictionary<string, int>> GetEventCountGroupedByTypeAsync();

        Task<Dictionary<Guid, int>> GetEventCountGroupedByUserAsync();

        Task<Dictionary<string, int>> GetEventCountByDateAsync();
    }
}
