using DevMetrics.Application.Interfaces;
using DevMetrics.Domain.Entities;
using DevMetrics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevMetrics.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DevMetricsDbContext _context;

        public EventRepository(DevMetricsDbContext context)
        {
            _context = context;
        }

        public Task AddEventAsync(Event ev)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetAllEventsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, int>> GetEventCountByDateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetEventCountByTypeAsync(string type)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetEventCountByUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, int>> GetEventCountGroupedByTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<Guid, int>> GetEventCountGroupedByUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEventsByTypeAsync(string type)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEventsByUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEventsGroupedByTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalEventCountAsync()
        {
            throw new NotImplementedException();
        }
    }
}
