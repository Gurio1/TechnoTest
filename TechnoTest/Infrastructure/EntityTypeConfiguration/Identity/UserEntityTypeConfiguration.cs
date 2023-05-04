using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechnoTest.Models.Identity;

namespace TechnoTest.Infrastructure.EntityTypeConfiguration.Identity
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasOne(user => user.UserGroup)
                .WithMany(userGroup =>userGroup.Users)
                .HasForeignKey(c => c.UserGroupId);

            builder.HasOne(c => c.UserState)
                .WithMany()
                .HasForeignKey(c => c.UserStateId);
        }
    }
}