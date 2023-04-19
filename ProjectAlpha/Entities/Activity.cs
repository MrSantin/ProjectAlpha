using System.Security.Principal;

namespace ProjectAlpha.Entities
{
    public class Activity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public TaskStatus Status { get; set; }
        public List<Staff> Staff { get; set; }
        public List<Message> Message { get; set; }
        public List<byte[]> Document { get; set; }  
    }

    public enum TaskStatus
    {
        Completed,
        Pending,
        Delayed,
        Cancelled
    }

    public enum Priority
    {
        Normal,
        Low,
        High
    }
}
