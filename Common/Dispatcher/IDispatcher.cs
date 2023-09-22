/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using Common.Dispatcher.CommandProcessor;
using Common.Dispatcher.QueryProcessor;

namespace Common.Dispatcher
{
    public interface IDispatcher
    {
        Task RunAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
        Task<TResult> RunAsync<TResult>(ICommand<TResult> command);
        Task<TResult> RunAsync<TResult>(IQuery<TResult> query);
        TResult Run<TResult>(IQuery<TResult> query);
        TResult Run<TResult>(ICommand<TResult> command);
        void Run<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
