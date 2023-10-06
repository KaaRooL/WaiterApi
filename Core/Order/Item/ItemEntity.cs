using Core.Base.Entity;

namespace Core.Item;

public class ItemEntity: EntityBase
{
    public ItemId ItemId { get; set; }
    public string Name { get; private set; }
    public PriceValue Price { get; private set; }
    public OrderId OrderId { get; set; }
    public virtual OrderAggregate Order { get; set; }

    private ItemEntity()
    {
        
    }

    private ItemEntity(string itemName, PriceValue itemPrice)
    {
        ItemId = ItemId.Create();
        Price = itemPrice;
        Name = itemName;
    }

    public static ItemEntity Create(string itemName, PriceValue itemPrice) => new(itemName, itemPrice);

}