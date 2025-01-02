using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FunnyWebRazor.Models;

namespace FunnyWebRazor.Data
{
    // Dziedziczenie po IdentityDbContext umożliwia obsługę ról i użytkowników
    public class ApplicationDBContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        // DbSet dla użytkowników i innych danych
        public DbSet<Worklog> Worklogs { get; set; }

        // Konfiguracja modelu bazy danych
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Ważne, aby zachować wywołanie base

            // Możesz dodać dodatkową konfigurację, np. seeding użytkowników

            // Przykład konfiguracji użytkowników (możesz to odkomentować, jeśli chcesz dodać użytkowników do bazy)
            var passwordHasher = new PasswordHasher<User>();

            // modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = "1",
            //        FullName = "John Smith",
            //        UserName = "john.smith@example.com",
            //        Email = "john.smith@example.com",
            //        PasswordHash = passwordHasher.HashPassword(null, "pass")
            //    }
            //);

            // modelBuilder.Entity<Worklog>().HasData(
            //    new Worklog
            //    {
            //        Id = 1,
            //        UserId = "2",
            //        TaskName = "Develop login page UI",
            //        Description = "Designed and implemented login page",
            //        StartTime = new DateTime(2024, 1, 1, 9, 0, 0),
            //        EndTime = new DateTime(2024, 1, 1, 17, 0, 0)
            //    }
            //);
        }
    }
}
