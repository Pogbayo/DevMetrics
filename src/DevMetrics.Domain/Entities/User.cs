namespace DevMetrics.Domain.Entities
{
    public class User
    {
       public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();
    }
}
