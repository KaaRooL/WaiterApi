﻿// <auto-generated />
using System;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(WaiterDbContext))]
    partial class WaiterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("waiter")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.AmountEntity", b =>
                {
                    b.Property<Guid>("AmountId")
                        .HasColumnType("uuid")
                        .HasColumnName("amount_id");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at_utc");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<string>("Payer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("payer");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("value");

                    b.HasKey("AmountId");

                    b.HasIndex("OrderId");

                    b.ToTable("amounts", "waiter");
                });

            modelBuilder.Entity("Core.Item.ItemEntity", b =>
                {
                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_id");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at_utc");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("items", "waiter");
                });

            modelBuilder.Entity("Core.OrderAggregate", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at_utc");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("order_status");

                    b.Property<Guid>("TableId")
                        .HasColumnType("uuid")
                        .HasColumnName("table_id");

                    b.Property<decimal>("Tip")
                        .HasColumnType("numeric");

                    b.Property<int>("Version")
                        .HasColumnType("integer")
                        .HasColumnName("version");

                    b.Property<Guid>("WaiterId")
                        .HasColumnType("uuid")
                        .HasColumnName("waiter_id");

                    b.HasKey("OrderId");

                    b.HasIndex("TableId");

                    b.HasIndex("WaiterId");

                    b.ToTable("orders", "waiter");
                });

            modelBuilder.Entity("Core.TableEntity", b =>
                {
                    b.Property<Guid>("TableId")
                        .HasColumnType("uuid")
                        .HasColumnName("table_id");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean")
                        .HasColumnName("is_available");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at_utc");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("TableId");

                    b.ToTable("tables", "waiter");
                });

            modelBuilder.Entity("Core.WaiterEntity", b =>
                {
                    b.Property<Guid>("WaiterId")
                        .HasColumnType("uuid")
                        .HasColumnName("waiter_id");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at_utc");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("WaiterId");

                    b.ToTable("waiters", "waiter");
                });

            modelBuilder.Entity("Core.AmountEntity", b =>
                {
                    b.HasOne("Core.OrderAggregate", "Order")
                        .WithMany("Amounts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Core.Item.ItemEntity", b =>
                {
                    b.HasOne("Core.OrderAggregate", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Core.OrderAggregate", b =>
                {
                    b.HasOne("Core.TableEntity", "Table")
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.WaiterEntity", "Waiter")
                        .WithMany()
                        .HasForeignKey("WaiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");

                    b.Navigation("Waiter");
                });

            modelBuilder.Entity("Core.OrderAggregate", b =>
                {
                    b.Navigation("Amounts");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
