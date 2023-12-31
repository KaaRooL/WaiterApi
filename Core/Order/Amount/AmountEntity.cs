﻿using Core.Base.Entity;

namespace Core;

public class AmountEntity: EntityBase
{
    public AmountId AmountId { get; set; }
    public decimal Value { get; private set; }
    public PayerValue Payer { get; set; }
    public OrderId OrderId { get; set; }
    public virtual OrderAggregate Order { get; set; }

    private AmountEntity()
    {
        
    }
}