using Microsoft.EntityFrameworkCore;
using PortalAPI.Models;

namespace PortalAPI.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
