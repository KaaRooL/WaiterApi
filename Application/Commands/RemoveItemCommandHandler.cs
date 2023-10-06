using Common.Dispatcher.CommandProcessor;
using Core.Repositories;

namespace Application.Commands;

public class RemoveItemCommandHandler : ICommandHandlerAsync<RemoveItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderAggregateRepository _orderAggregateRepository;

    public RemoveItemCommandHandler(IUnitOfWork unitOfWork, IOrderAggregateRepository orderAggregateRepository)
    {
        _unitOfWork = unitOfWork;
        _orderAggregateRepository = orderAggregateRepository;
    }
    public async Task HandleAsync(RemoveItemCommand command)
    {
        var order = await _orderAggregateRepository.GetAsync(command.OrderId);
        
        if (order is null)
        {
            throw new ApplicationException($"Order with id {command.OrderId} not exists");
        }
        var itemToRemove = order.Items.FirstOrDefault(i => i.ItemId.Id == command.ItemId);

        if (itemToRemove is null)
        {
            throw new ApplicationException($"Item with id: {command.ItemId} not exists");
        }
        order.RemoveItem(itemToRemove);
        
        await _unitOfWork.SaveChangesAsync();
    }
}