using Core.Base.Type;

namespace Core;

public class AmountId : GuidId
{
    public AmountId(Guid id) : base(id)
    {
    }

    public static implicit operator AmountId(Guid id) => new(id);
    
    public static AmountId Create() => new(Guid.NewGuid());
}