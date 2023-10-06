using Application.Dto;
using Core;

namespace Application;

public static class OrdersMapper
{
    public static OrderDto AsDto(this OrderAggregate orderAggregate) =>
            new(orderAggregate.OrderId, orderAggregate.Table.Name);

}