using Core.Base.Type;

namespace Core;

public class WaiterId: GuidId
{
    public WaiterId(Guid id) : base(id)
    {
    }
    
    public static implicit operator WaiterId(Guid id) => new(id);
    
    public static WaiterId Create() => new(Guid.NewGuid());
}