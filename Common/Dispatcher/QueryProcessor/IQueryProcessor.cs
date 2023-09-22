/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
namespace Common.Dispatcher.QueryProcessor
{
    public interface IQueryProcessor
    {
        Task<T1> QueryAsync<T1>(IQuery<T1> query);
        TResult Query<TResult>(IQuery<TResult> query);
    }
}
