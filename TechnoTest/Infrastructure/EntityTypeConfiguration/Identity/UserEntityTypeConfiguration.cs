﻿using System;
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
                .WithMany()
                .HasForeignKey(c => c.UserGroupId);

            builder.HasOne(c => c.UserState)
                .WithMany()
                .HasForeignKey(c => c.UserStateId);
            
            builder.Property(e => e.RegistrationDate)
                .HasColumnType("timestamp without time zone")
                .HasConversion(
                    v => v.ToLocalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                );
        }
    }
}