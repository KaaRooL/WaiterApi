using Common.Dispatcher.CommandProcessor;

namespace Application.Commands;

public record RemoveItemCommand(Guid OrderId, Guid ItemId) : ICommand;