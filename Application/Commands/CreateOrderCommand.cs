using Common.Dispatcher.CommandProcessor;

namespace Application.Commands;

public record CreateOrderCommand(Guid TableId): ICommand;