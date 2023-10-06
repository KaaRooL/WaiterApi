/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */

using Core.Base.Aggregate;
using Core.DomainEvent;
using Core.Item;
using Core.Order.DomainEvents;

namespace Core;

public class OrderAggregate : AggregateRootBase
{
    private ISet<AmountEntity> _amountValues = new HashSet<AmountEntity>();
    private ISet<ItemEntity> _items = new HashSet<ItemEntity>();
    public virtual IEnumerable<AmountEntity> Amounts
    {
        get => _amountValues;
        private set => _amountValues = new HashSet<AmountEntity>(value);
    }

    public virtual IEnumerable<ItemEntity> Items
    {
        get => _items;
        private set => _items = new HashSet<ItemEntity>(value);
    }
    public OrderId OrderId { get; set; }
    public decimal Tip { get; set; }
    public string OrderStatus { get; set; }
    public WaiterId WaiterId { get; set; }
    public virtual WaiterEntity Waiter { get; set; }
    public TableId TableId { get; set; }
    public virtual TableEntity Table { get; set; }

    private OrderAggregate()
    {
        
    }
    
    private OrderAggregate(WaiterEntity waiter, TableEntity table)
    {
        Waiter = waiter;
        Table = table;
        OrderId = Guid.NewGuid();
        OrderStatus = OrderStatusDictionary.Open;
        AddEvent(new OrderCreatedEvent(this));
    }
    

    public static OrderAggregate Create(WaiterEntity waiter, TableEntity table)
    {
        return new OrderAggregate(waiter, table);
    }

    public void AddItem(ItemEntity item)
    {
        _items.Add(item);
        AddItemsChangedEvent();
    }

    private void AddItemsChangedEvent()
    {
        AddEvent(new ItemsChangesEvent(this));
    }

    public void AddAmount(AmountEntity amount)
    {
        _amountValues.Add(amount);
    }

    public void RemoveItem(ItemEntity item)
    {
        _items.Remove(item);
        AddItemsChangedEvent();
    }

    public void Close()
    {
        OrderStatus = OrderStatusDictionary.Closed;
    }
}