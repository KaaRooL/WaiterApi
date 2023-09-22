/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<OrderAggregate>
{
    // public void Configure(EntityTypeBuilder<UserEntity> builder)
    // {
    //     builder.ToTable("users");
    //     builder.HasKey(u => u.UserId);
    //     builder.Property(u => u.UserId).HasColumnName("user_id").IsRequired();
    //     builder.Property(u => u.Name).HasColumnName("name").IsRequired(); // Assume UserName is required
    //     builder.Property(u => u.Email).HasColumnName("email").IsRequired();
    // }
    public void Configure(EntityTypeBuilder<OrderAggregate> builder)
    {
        throw new NotImplementedException();
    }
}
