using FunnyWebRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace FunnyWebRazor.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Worklog> Worklogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team 
                { 
                    Id = 1, 
                    Name = "Development" 
                },
                new Team 
                { 
                    Id = 2, 
                    Name = "Marketing" 
                },
                new Team 
                { 
                    Id = 3,
                    Name = "HR" 
                }
            );

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   FullName = "John Smith",
                   Email = "john.smith@example.com",
                   Password = "pass",
                   Role = "Employer"
               },
               new User
               {
                   Id = 2,
                   FullName = "Jane Doe",
                   Email = "jane.doe@example.com",
                   Password = "pass",
                   Role = "Employee"
               },
               new User
               {
                   Id = 3,
                   FullName = "Alice Johnson",
                   Email = "alice.johnson@example.com",
                   Password = "pass",
                   Role = "Employee"
               }
            );


            modelBuilder.Entity<Worklog>().HasData(
                new Worklog
                {
                    Id = 1,
                    UserId = 2,
                    TaskName = "Develop login page UI",
                    Description = "Designed and implemented login page",
                    StartTime = new DateTime(2024, 1, 1, 9, 0, 0),
                    EndTime = new DateTime(2024, 1, 1, 17, 0, 0)
                },
                new Worklog
                {
                    Id = 2,
                    UserId = 3,
                    TaskName = "Prepare marketing plan",
                    Description = "Worked on the Q1 marketing strategy",
                    StartTime = new DateTime(2024, 1, 2, 10, 0, 0),
                    EndTime = new DateTime(2024, 1, 2, 15, 0, 0)
                }
            );
        }
    }
}