using JWT_Application.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace JWT_Application.DbContext
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base (option) 
        {
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}
