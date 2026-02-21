namespace DevMetrics.Domain.Entities
{

    public enum EventType
    {
        Unknown = 0,
        ProjectCreated = 1,
        ProjectUpdated = 2,
        ProjectDeleted = 3,
        UserJoinedProject = 4,
        UserLeftProject = 5,
        EventLogged = 6,
        CommentAdded = 7,
        CommentDeleted = 8
    }

    public class Event
    {
            public long Id { get; set; }

            public EventType EventType { get; set; }  

            public Guid UserId { get; set; }
            //public User User { get; set; } = default!;

            public DateTime Timestamp { get; set; }

            public long ProjectId { get; set; }
            public Project Project { get; set; } = default!;
    }
}
