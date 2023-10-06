using Core.DomainEvent;

namespace Core.Order.DomainEvents;

internal class OrderCreatedEvent : IDomainEvent
{
    public OrderCreatedEvent(OrderAggregate orderAggregate)
    {
        
    }
}