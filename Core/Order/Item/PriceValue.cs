namespace Core.Item;

public class PriceValue
{
    private PriceValue(decimal value)
    {
        
        if (value <= 0)
        {
            throw new ApplicationException("Price for item cannot be lower than 0");
        }

        if (!HasTwoDecimalPlacesOrLess(value))
        {
            throw new ApplicationException("Price cannot have more than two decimal places");
        }

        Value = value;
    }

    private static bool HasTwoDecimalPlacesOrLess(decimal value)
    {
        return Math.Round(value, 2).Equals(value);
    }

    public decimal Value { get; private set; }

    public static PriceValue Create(decimal value) => new(value);
}