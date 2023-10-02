/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */

using Core;
using Core.Item;
using Infrastructure.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EntityFramework;

public class WaiterDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public virtual DbSet<OrderAggregate> Orders { get; set; }
    public virtual DbSet<ItemEntity> Items { get; set; }
    public virtual DbSet<WaiterEntity> Waiters { get; set; }
    public virtual DbSet<TableEntity> Tables { get; set; }
    public virtual DbSet<AmountEntity> Amounts { get; set; }

    public WaiterDbContext()
    {
        
    }
    public WaiterDbContext(DbContextOptions<WaiterDbContext> options, IConfiguration configuration):base(options)
    {
        _configuration = configuration;

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("waiter");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.ApplyConfiguration(new AmountEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderAggregateConfiguration());
        modelBuilder.ApplyConfiguration(new TableEntityConfiguration());
        modelBuilder.ApplyConfiguration(new WaiterEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string? connectionString = _configuration.GetConnectionString("WaiterApiDatabase");
        
        options.UseNpgsql(connectionString);
    }
}

