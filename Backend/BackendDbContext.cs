using Backend.Data;
using Backend.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class BackendDbContext:IdentityDbContext<ApiUser>
    {
        public BackendDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Trim> Trims { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Company>().HasMany(e => e.Models)
                .WithOne(e => e.Company).IsRequired().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Model>().HasMany(e => e.Bodies)
                .WithOne(e => e.Model).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Model>().HasMany(e => e.Trims)
                            .WithOne(e => e.Model).IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new ModelsConfiguration());

        }

    }
}
