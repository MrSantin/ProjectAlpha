namespace ProjectAlpha.Entities
{
    public class Staff : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Staff()
        {
            
        }
    }
}
