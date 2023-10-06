using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class OrderAggregateConfiguration : IEntityTypeConfiguration<OrderAggregate>
{
    public void Configure(EntityTypeBuilder<OrderAggregate> builder)
    {
        builder.ToTable("orders");
        builder.HasKey(o=>o.OrderId);
        builder.Property(u=>u.OrderId).HasColumnName("order_id").HasConversion(wai => wai.Id, dbValue => new OrderId(dbValue)).IsRequired();
        builder.Property(u=>u.WaiterId).HasColumnName("waiter_id").HasConversion(wai => wai.Id, dbValue => new WaiterId(dbValue)).IsRequired();
        builder.Property(u=>u.TableId).HasColumnName("table_id").HasConversion(wai => wai.Id, dbValue => new TableId(dbValue)).IsRequired();
        builder.Property(u=>u.OrderStatus).HasColumnName("order_status").IsRequired();
        builder.Property(u=>u.Version).HasColumnName("version").IsRequired();

        builder.HasMany(u => u.Items).WithOne(i => i.Order).HasForeignKey(i=>i.OrderId);
        builder.HasMany(u => u.Amounts).WithOne(a => a.Order).HasForeignKey(a => a.OrderId);
        builder.HasOne(o=>o.Table).WithMany().HasForeignKey(o=>o.TableId);
    }
}