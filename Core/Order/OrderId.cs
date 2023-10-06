using Core.Base.Type;

namespace Core;

public class OrderId : GuidId
{
    public OrderId(Guid id) : base(id)
    {
    }

    public static implicit operator OrderId(Guid id) => new(id);
    
    public static OrderId Create() => new(Guid.NewGuid());
}