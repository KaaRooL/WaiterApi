using Application.Dto;
using Common.Dispatcher.QueryProcessor;
using Core.Repositories;

namespace Application.Queries;

public class GetOrdersQueryHandler : IQueryHandlerAsync<GetOrdersQuery, OrdersDto>
{
    private readonly IOrderAggregateRepository _orderAggregateRepository;

    public GetOrdersQueryHandler(IOrderAggregateRepository orderAggregateRepository)
    {
        _orderAggregateRepository = orderAggregateRepository;
    }

    public async Task<OrdersDto> HandleAsync(GetOrdersQuery query)
    {
        var orders = await _orderAggregateRepository.GetAllAsync();
        return new OrdersDto(orders.Select(o => o.AsDto()).ToArray());
    }
}