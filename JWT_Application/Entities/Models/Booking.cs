namespace JWT_Application.Entities.Models
{
    public class Booking:BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
