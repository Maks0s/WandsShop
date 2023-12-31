﻿using Domain.Entities;
using Infrastructure.Persistence.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class WandsDbContext : DbContext
    {
        public DbSet<Wand> Wands { get; set; }

        public WandsDbContext(DbContextOptions<WandsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
