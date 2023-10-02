using Core.Base.Type;

namespace Core.Item;

public class ItemId : GuidId
{
    public ItemId(Guid id) : base(id)
    {
    }

    public static implicit operator ItemId(Guid id) => new(id);
    
    public static ItemId Create() => new(Guid.NewGuid());
};