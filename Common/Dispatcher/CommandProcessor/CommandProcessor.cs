/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */

using Microsoft.Extensions.DependencyInjection;

namespace Common.Dispatcher.CommandProcessor
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CommandProcessor(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandlerAsync<TCommand>>();

            await handler.HandleAsync(command);
        }

        public void Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var scope = _serviceScopeFactory.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            handler.Handle(command);
        }

        public async Task<TResult> SendAsync<TResult>(ICommand<TResult> command)
        {
            var typeArgument = command.GetType();
            var handlerType = typeof(ICommandHandlerAsync<,>).MakeGenericType(typeArgument, typeof(TResult));

            using var scope = _serviceScopeFactory.CreateScope();
            var handler = (dynamic)scope.ServiceProvider.GetRequiredService(handlerType);
            return await handler.HandleAsync((dynamic)command);
        }

        public TResult Send<TResult>(ICommand<TResult> command)
        {
            var typeArgument = command.GetType();
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(typeArgument, typeof(TResult));

            using var scope = _serviceScopeFactory.CreateScope();
            var handler = (dynamic)scope.ServiceProvider.GetRequiredService(handlerType);
            return handler.Handle((dynamic)command);
        }
    }
}