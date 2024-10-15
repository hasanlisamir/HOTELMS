using HOTELMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HOTELMS.Context
{
    public class HOTELMSDbContext:DbContext
    {
        public HOTELMSDbContext(DbContextOptions<HOTELMSDbContext> option) : base(option) {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room>Rooms { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
