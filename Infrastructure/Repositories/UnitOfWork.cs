/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using Core.Repositories;
using Infrastructure.EntityFramework;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly WaiterDbContext _context;

    public UnitOfWork(WaiterDbContext context)
    {
        _context = context;
    }

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
