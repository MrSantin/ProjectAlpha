namespace ProjectAlpha.Entities
{
    public class Project : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Activity> Activities { get; set; }
        public Staff ProjectOwner { get; set; }

        public Project() { 
        }
    }
}
