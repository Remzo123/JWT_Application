using Microsoft.AspNetCore.Identity;

namespace JWT_Application.Entities.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
