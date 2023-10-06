namespace Common.Dispatcher.CommandProcessor;

public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}