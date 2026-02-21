namespace DevMetrics.Domain.Entities
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Event> Events { get; set; } = new List<Event>();
 
        public ICollection<UserProject> UserProjects { get; set; }  = new List<UserProject>();
    }

}
