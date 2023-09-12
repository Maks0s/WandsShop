using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
