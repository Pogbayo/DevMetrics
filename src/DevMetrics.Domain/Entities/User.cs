namespace DevMetrics.Domain.Entities
{
    public class User
    {
       public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int ProjectCount { get; set; } = 0;
        //public ICollection<Event> Events { get; set; } = new List<Event>();
        //public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();
    }
}
