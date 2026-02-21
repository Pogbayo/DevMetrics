namespace DevMetrics.Domain.Entities
{
    public class Shard
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
