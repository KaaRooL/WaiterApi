using Core.Base.Type;

namespace Core;

public class TableId : GuidId
{
    private TableId(Guid id) : base(id)
    {
    }

    public static implicit operator TableId(Guid id) => new(id);
    
    public static TableId Create() => new(Guid.NewGuid());
}