/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */

using Common;
using Core.Base.Audit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.EntityFramework;

public class AuditableInterceptor : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuditableInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = new())
    {
        FillAuditableProperties(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void FillAuditableProperties(DbContext context)
    {
        var entries = context.ChangeTracker.Entries<Auditable>();

        string userName = (_httpContextAccessor?.HttpContext != null
                ? IdentityHelper.GetUserInfo(_httpContextAccessor.HttpContext.User).Username
                : "system")!;

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(e => e.CreatedBy).CurrentValue = userName;
                entry.Property(e => e.CreatedAtUtc).CurrentValue = DateTime.UtcNow;
                entry.Property(e => e.ModifiedAtUtc).CurrentValue = DateTime.UtcNow;
                entry.Property(e => e.ModifiedBy).CurrentValue = userName;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Property(e => e.ModifiedAtUtc).CurrentValue = DateTime.UtcNow;
                entry.Property(e => e.ModifiedBy).CurrentValue = userName;
            }
        }
    }
}