using Application.Dto;
using Common.Dispatcher.QueryProcessor;

namespace Application.Queries;

public record GetOrdersQuery : IQuery<OrdersDto>;