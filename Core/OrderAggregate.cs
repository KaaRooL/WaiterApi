/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */

using System.Reflection.Metadata.Ecma335;
using Core.Base.Aggregate;
using Core.Base.Type;
using Core.Item;

namespace Core;

public class OrderAggregate : AggregateRootBase
{
    private ISet<AmountEntity> _amountValues;
    private ISet<ItemEntity> _items;
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
    public WaiterEntity Waiter { get; set; }
    public TableId TableId { get; set; }
    public TableEntity Table { get; set; }

    public OrderAggregate()
    {
        
    }
    
    private OrderAggregate(WaiterEntity waiter, TableEntity table)
    {
        Waiter = waiter;
        Table = table;
        OrderId = Guid.NewGuid();
        OrderStatus = OrderStatusDictionary.Open;
    }
    

    public static OrderAggregate Create(WaiterEntity waiter, TableEntity table)
    {
        return new OrderAggregate(waiter, table);
    }

    public void AddItem(ItemEntity item)
    {
        _items.Add(item);
    }

    public void AddAmount(AmountEntity amount)
    {
        _amountValues.Add(amount);
    }

    public void RemoveItem(ItemEntity item)
    {
        _items.Remove(item);
    }

    public void Close()
    {
        OrderStatus = OrderStatusDictionary.Closed;
    }
}