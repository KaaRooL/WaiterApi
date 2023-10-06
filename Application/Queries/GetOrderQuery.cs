using Application.Dto;
using Common.Dispatcher.QueryProcessor;

namespace Application.Queries;

public record GetOrderQuery(Guid OrderId) : IQuery<OrderDto>;