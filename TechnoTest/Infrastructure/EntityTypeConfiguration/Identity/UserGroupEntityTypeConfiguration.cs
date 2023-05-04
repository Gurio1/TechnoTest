using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechnoTest.Models.Identity;

namespace TechnoTest.Infrastructure.EntityTypeConfiguration.Identity
{
    public class UserGroupEntityTypeConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable("User_Groups");

            builder.Property(c => c.Code).IsRequired().HasMaxLength(40);
            builder.Property(c => c.Description).HasMaxLength(150);

        }
    }
}