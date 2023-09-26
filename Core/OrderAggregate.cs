/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */

using System.Reflection.Metadata.Ecma335;
using Core.Base.Aggregate;
using Core.Base.Entity;
using Core.Base.Type;
using Core.Item;

namespace Core;

public class OrderAggregate: AggregateRootBase
{
    private ISet<AmountEntity> _amountValues;
    private ISet<ItemEntity> _items;
    public TableEntity Table { get; set; }
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

}

public class AmountEntity: EntityBase
{
    public AmountId AmountId { get; set; }
    public decimal Value { get; private set; }
    public PayerValue Payer { get; set; }
    
}

public class PayerValue
{
}

public class AmountId : GuidId
{
    private AmountId(Guid id) : base(id)
    {
    }

    public static implicit operator AmountId(Guid id) => new(id);
    
    public static AmountId Create() => new(Guid.NewGuid());
}