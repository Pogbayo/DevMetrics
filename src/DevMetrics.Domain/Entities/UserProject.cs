

namespace DevMetrics.Domain.Entities
{
    public class UserProject
    {
        public long UserId { get; set; }
        public User User { get; set; } = new User();

        public long ProjectId { get; set; }
        public Project Project { get; set; } = new Project();

        public DateTime JoinedAt { get; set; }
    }
}
