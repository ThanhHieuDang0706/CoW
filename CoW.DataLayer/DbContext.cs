using CoW.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoW.DataLayer
{
    public class CoWDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CoWDbContext(DbContextOptions<CoWDbContext> options) : base(options)
        {
        }
    }
}
