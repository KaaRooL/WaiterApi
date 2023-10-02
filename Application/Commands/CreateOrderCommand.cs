using Common.Dispatcher.CommandProcessor;
using Core;

namespace Application.Commands;

public record CreateOrderCommand(Guid TableId,  string WaiterName, string WaiterId): ICommand;


public class CreateOrderCommandHandler : ICommandHandlerAsync<CreateOrderCommand>
{
    public Task HandleAsync(CreateOrderCommand command)
    {
        TableEntity table = null;//pobrac z repo
        var order = OrderAggregate.Create(WaiterEntity.Create(command.WaiterName, command.WaiterId), table);
        
    }
}