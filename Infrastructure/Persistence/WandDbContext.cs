using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class WandDbContext : DbContext
    {
        public DbSet<Wand> Wands { get; set; }

        public WandDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
