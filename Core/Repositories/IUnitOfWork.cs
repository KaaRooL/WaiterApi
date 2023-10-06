/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
namespace Core.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}