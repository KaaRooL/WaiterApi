using Common;
using Common.Dispatcher.CommandProcessor;
using Core;
using Core.Repositories;

namespace Application.Commands;

public class CreateOrderCommandHandler : ICommandHandlerAsync<CreateOrderCommand>
{
    private readonly IOrderAggregateRepository _orderAggregateRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIdentityService _identityService;
    public CreateOrderCommandHandler(IOrderAggregateRepository orderAggregateRepository, IUnitOfWork unitOfWork, IIdentityService identityService)
    {
        _orderAggregateRepository = orderAggregateRepository;
        _unitOfWork = unitOfWork;
        _identityService = identityService;
    }
    public async Task HandleAsync(CreateOrderCommand command)
    {
        TableEntity table = TableEntity.Create($"Table1{new Random().Next(100)}");
        var userInfo = _identityService.UserInfo();
        var order = OrderAggregate.Create(WaiterEntity.Create(userInfo.Username), table);
        await _orderAggregateRepository.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();
    }
}