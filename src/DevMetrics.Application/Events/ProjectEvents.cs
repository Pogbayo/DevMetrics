namespace DevMetrics.Application.Events
{
    public class ProjectEvents
    {
        public event Action<long, Guid, DateTime>? ProjectCreated;

        public void RaiseProjectCreated(long projectId, Guid creatorUserId, DateTime createdAt)
        {
            ProjectCreated?.Invoke(projectId, creatorUserId, createdAt);
        }
    }
}
