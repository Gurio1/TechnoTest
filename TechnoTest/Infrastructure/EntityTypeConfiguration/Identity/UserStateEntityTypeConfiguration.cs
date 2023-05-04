using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechnoTest.Models.Identity;

namespace TechnoTest.Infrastructure.EntityTypeConfiguration.Identity
{
    public class UserStateEntityTypeConfiguration : IEntityTypeConfiguration<UserState>
    {
        public void Configure(EntityTypeBuilder<UserState> builder)
        {
            builder.ToTable("User_States");
            
            builder.Property(c => c.Code).IsRequired().HasMaxLength(40);
            builder.Property(c => c.Description).HasMaxLength(150);
        }
    }
}