namespace JWT_Application.Entities.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; }= DateTime.Now;
        public DateTime UpdatedTime { get; set; }
    }
}
