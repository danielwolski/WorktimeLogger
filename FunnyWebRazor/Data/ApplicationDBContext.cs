using FunnyWebRazor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FunnyWebRazor.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        // DbSet tylko dla Team
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Dane początkowe dla Team
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Development Team" },
                new Team { Id = 2, Name = "Marketing Team" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
