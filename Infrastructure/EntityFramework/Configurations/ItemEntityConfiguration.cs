using Core;
using Core.Item;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class ItemEntityConfiguration : IEntityTypeConfiguration<ItemEntity>
{
    public void Configure(EntityTypeBuilder<ItemEntity> builder)
    {
        builder.ToTable("items");
        builder.HasKey(o=>o.ItemId);
        builder.Property(u=>u.ItemId).HasColumnName("item_id").HasConversion(wai => wai.Id, dbValue => new ItemId(dbValue)).IsRequired();
        builder.Property(u=>u.OrderId).HasColumnName("order_id").HasConversion(wai => wai.Id, dbValue => new OrderId(dbValue)).IsRequired();
        builder.Property(a => a.Price).HasColumnName("price").HasConversion(i => i.Value , dbValue => PriceValue.Create(dbValue)).IsRequired();
        builder.Property(a => a.Name).HasColumnName("name").IsRequired();
    }
}