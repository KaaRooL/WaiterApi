using Application.Dto;
using Core;
using Core.Item;

namespace Application;

public static class OrdersMapper
{
    public static OrderDto AsDto(this OrderAggregate orderAggregate) =>
            new(orderAggregate.OrderId, orderAggregate.Table.Name, orderAggregate.Items.Select(i=>i.AsDto()).ToArray());

    public static ItemDto AsDto(this ItemEntity itemEntity) =>
            new(itemEntity.ItemId.Id, itemEntity.Name, itemEntity.Price.Value);

}