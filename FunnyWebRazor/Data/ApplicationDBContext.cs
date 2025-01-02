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
                },
                new User
                {
                    Id = 4,
                    FullName = "Bob Brown",
                    Email = "bob.brown@example.com",
                    Password = "pass",
                    Role = "Employee"
                },
                new User
                {
                    Id = 5,
                    FullName = "Charlie Black",
                    Email = "charlie.black@example.com",
                    Password = "pass",
                    Role = "Manager"
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
                },
                new Worklog
                {
                    Id = 3,
                    UserId = 4,
                    TaskName = "Fix API bugs",
                    Description = "Resolved critical API bugs for the payment module",
                    StartTime = new DateTime(2024, 1, 3, 11, 0, 0),
                    EndTime = new DateTime(2024, 1, 3, 18, 0, 0)
                },
                new Worklog
                {
                    Id = 4,
                    UserId = 5,
                    TaskName = "Team meeting",
                    Description = "Weekly team sync-up and project updates",
                    StartTime = new DateTime(2024, 1, 4, 9, 0, 0),
                    EndTime = new DateTime(2024, 1, 4, 10, 30, 0)
                },
                new Worklog
                {
                    Id = 5,
                    UserId = 2,
                    TaskName = "Design homepage",
                    Description = "Created a prototype for the new homepage design",
                    StartTime = new DateTime(2024, 1, 5, 9, 0, 0),
                    EndTime = new DateTime(2024, 1, 5, 16, 0, 0)
                },
                new Worklog
                {
                    Id = 6,
                    UserId = 3,
                    TaskName = "Content creation",
                    Description = "Wrote articles and blog posts for Q1 marketing",
                    StartTime = new DateTime(2024, 1, 6, 8, 0, 0),
                    EndTime = new DateTime(2024, 1, 6, 13, 0, 0)
                },
                new Worklog
                {
                    Id = 7,
                    UserId = 4,
                    TaskName = "Code review",
                    Description = "Reviewed pull requests and improved code quality",
                    StartTime = new DateTime(2024, 1, 7, 14, 0, 0),
                    EndTime = new DateTime(2024, 1, 7, 18, 0, 0)
                },
                new Worklog
                {
                    Id = 8,
                    UserId = 5,
                    TaskName = "Strategic planning",
                    Description = "Defined long-term goals for the team",
                    StartTime = new DateTime(2024, 1, 8, 10, 0, 0),
                    EndTime = new DateTime(2024, 1, 8, 14, 0, 0)
                }
            );

        }
    }
}