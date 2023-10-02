using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class WaiterEntityConfiguration : IEntityTypeConfiguration<WaiterEntity>
{
    public void Configure(EntityTypeBuilder<WaiterEntity> builder)
    {
        builder.ToTable("waiters");
        builder.HasKey(o=>o.WaiterId);
        builder.Property(u=>u.WaiterId).HasColumnName("waiter_id").HasConversion(wai => wai.Id, dbValue => new WaiterId(dbValue)).IsRequired();
        builder.Property(u=>u.Name).HasColumnName("name").IsRequired();
    }
}