using Application.Dto;
using Common.Dispatcher.QueryProcessor;
using Core;
using Core.Repositories;

namespace Application.Queries;

public class GetOrderQueryHandler : IQueryHandlerAsync<GetOrderQuery, OrderDto>
{
    private readonly IOrderAggregateRepository _orderAggregateRepository;

    public GetOrderQueryHandler(IOrderAggregateRepository orderAggregateRepository)
    {
        _orderAggregateRepository = orderAggregateRepository;
    }

    public async Task<OrderDto> HandleAsync(GetOrderQuery query)
    {
        var order = await _orderAggregateRepository.GetAsync(new OrderId(query.OrderId));

        if (order is null)
        {
            throw new ApplicationException($"Order with id {query.OrderId} does not exist");
        }
        return order.AsDto();
    }
}