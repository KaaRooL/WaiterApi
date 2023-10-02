using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class TableEntityConfiguration : IEntityTypeConfiguration<TableEntity>
{
    public void Configure(EntityTypeBuilder<TableEntity> builder)
    {
        builder.ToTable("tables");
        builder.HasKey(o=>o.TableId);
        builder.Property(u=>u.TableId).HasColumnName("table_id").HasConversion(wai => wai.Id, dbValue => new TableId(dbValue)).IsRequired();
        builder.Property(u=>u.Name).HasColumnName("name").IsRequired();
        builder.Property(u=>u.IsAvailable).HasColumnName("is_available").IsRequired();
    }
}