using DevMetrics.Application.Events;
using DevMetrics.Domain.Entities;

namespace DevMetrics.Application.Listeners
{
    public class CentralMappingListener
    {
        private readonly CentralDbContext _centralDb;
        private readonly ProjectEvents _events;

        public CentralMappingListener(CentralDbContext centralDb, ProjectEvents events)
        {
            _centralDb = centralDb;
            _events = events;

            // Subscribe once when the class is created
            _events.ProjectCreated += OnProjectCreated;
        }

        private async void OnProjectCreated(long projectId, Guid creatorUserId, DateTime createdAt)
        {
            var userProject = new UserProject
            {
                ProjectId = projectId,
                UserId = creatorUserId,
                JoinedAt = createdAt
            };

            _centralDb.UserProject.Add(userProject);
            await _centralDb.SaveChangesAsync();

            Console.WriteLine($"Central mapping added for project {projectId}");
        }

        public void Dispose()
        {
            _events.ProjectCreated -= OnProjectCreated;
        }
    }
}
