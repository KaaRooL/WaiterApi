/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
namespace Common.Dispatcher.CommandProcessor
{
    public interface ICommandProcessor
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
        void Send<TCommand>(TCommand command) where TCommand : class, ICommand;
        Task<TResult> SendAsync<TResult>(ICommand<TResult> command);
        TResult Send<TResult>(ICommand<TResult> command);


    }
}


