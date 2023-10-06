using Common.Dispatcher.CommandProcessor;
using Core.Item;
using Core.Repositories;

namespace Application.Commands;

public class AddItemCommandHandler : ICommandHandlerAsync<AddItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderAggregateRepository _orderAggregateRepository;

    public AddItemCommandHandler(IUnitOfWork unitOfWork, IOrderAggregateRepository orderAggregateRepository)
    {
        _unitOfWork = unitOfWork;
        _orderAggregateRepository = orderAggregateRepository;
    }
    public async Task HandleAsync(AddItemCommand command)
    {
        var item = ItemEntity.Create(command.Item.Name, PriceValue.Create(command.Item.Price));
        var order = await _orderAggregateRepository.GetAsync(command.OrderId);
        
        if (order is null)
        {
            throw new ApplicationException($"Order with id {command.OrderId} does not exist");
        }
        
        order.AddItem(item);
        await _unitOfWork.SaveChangesAsync();
    }
}