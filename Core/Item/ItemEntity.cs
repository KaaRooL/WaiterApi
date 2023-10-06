using Core.Base.Entity;

namespace Core.Item;

public class ItemEntity: EntityBase
{
    public ItemId ItemId { get; set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public OrderId OrderId { get; set; }
    public virtual OrderAggregate Order { get; set; }

    private ItemEntity()
    {
        
    }
    
}