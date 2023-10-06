using Common.Dispatcher.CommandProcessor;
using Core.Repositories;

namespace Application.Commands;

public class UpdateItemsCommandHandler : ICommandHandlerAsync<UpdateItemsCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderAggregateRepository _orderAggregateRepository;

    public UpdateItemsCommandHandler(IUnitOfWork unitOfWork, IOrderAggregateRepository orderAggregateRepository)
    {
        _unitOfWork = unitOfWork;
        _orderAggregateRepository = orderAggregateRepository;
    }

    public async Task HandleAsync(UpdateItemsCommand command)
    {
        var order = await _orderAggregateRepository.GetAsync(command.OrderId);

        if (order is null)
        {
            throw new ApplicationException($"Order with id {command.OrderId} does not exist");
        }
    }
}