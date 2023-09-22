/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using Core.Base.Aggregate;

namespace Core;

public class OrderAggregate: AggregateRootBase
{
    private readonly HashSet<AmountValue> _amountValues;

    public HashSet<AmountValue> AmountValues
    {
        get
        {
            return _amountValues;
        }
    }

}

public class AmountValue
{
}
