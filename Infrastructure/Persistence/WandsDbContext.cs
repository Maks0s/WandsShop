using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class WandsDbContext : DbContext
    {
        public DbSet<Wand> Wands { get; set; }

        public WandsDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
