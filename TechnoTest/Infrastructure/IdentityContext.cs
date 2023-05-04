using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TechnoTest.Models.Identity;

namespace TechnoTest.Infrastructure
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserState> UserStates { get; set; }
    }
}