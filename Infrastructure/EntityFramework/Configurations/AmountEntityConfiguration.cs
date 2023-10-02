using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class AmountEntityConfiguration : IEntityTypeConfiguration<AmountEntity>
{
    public void Configure(EntityTypeBuilder<AmountEntity> builder)
    {
        builder.ToTable("amounts");
        builder.HasKey(o=>o.AmountId);
        builder.Property(u=>u.AmountId).HasColumnName("amount_id").HasConversion(wai => wai.Id, dbValue => new AmountId(dbValue)).IsRequired();
        builder.Property(u=>u.OrderId).HasColumnName("order_id").HasConversion(wai => wai.Id, dbValue => new OrderId(dbValue)).IsRequired();
        builder.Property(a => a.Value).HasColumnName("value").IsRequired();
        builder.Property(a => a.Payer).HasColumnName("payer").HasConversion(wai => wai.Email, dbValue => PayerValue.Create(dbValue)).IsRequired();
        // builder.OwnsOne(p => p.Payer, quantityPicked =>
        // {
        //     quantityPicked.Property(f => f.Email).HasColumnName("quantity_picked");
        // });
    }
}