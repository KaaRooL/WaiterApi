/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EntityFramework;

public class WaiterDbContext : DbContext
{
    private readonly IConfiguration _configuration;
//    public DbSet<UserEntity> Users { get; set; }

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
//        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string? connectionString = _configuration.GetConnectionString("WaiterApiDatabase");
        
        options.UseNpgsql(connectionString);
    }
}

