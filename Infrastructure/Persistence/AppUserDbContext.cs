using Domain.Entities;
using Infrastructure.Persistence.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppUserDbContext : IdentityDbContext<AppUser>
    {
        public AppUserDbContext(DbContextOptions<AppUserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(DbSchemas.UsersSchema);
        }
    }
}
