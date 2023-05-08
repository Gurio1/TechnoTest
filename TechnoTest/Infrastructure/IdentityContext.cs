using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TechnoTest.Domain.Models.Identity;

namespace TechnoTest.Infrastructure
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed UserGroup
            modelBuilder.Entity<UserGroup>().HasData(
                new UserGroup() { Id = 1, Code = "Admin", Description = "Administrator" },
                new UserGroup() { Id = 2, Code = "User", Description = "Regular User" });

            // Seed UserState
            modelBuilder.Entity<UserState>().HasData(
                new UserState() { Id = 1, Code = "Active", Description = "Active User" },
                new UserState() { Id = 2, Code = "Blocked", Description = "Blocked User" });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserState> UserStates { get; set; }
    }
}