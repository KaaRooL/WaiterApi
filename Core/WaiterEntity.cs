using Core.Base.Entity;

namespace Core;

public class WaiterEntity: EntityBase
{
    public WaiterId WaiterId { get; set; }
    public string Name { get; set; }

    private WaiterEntity()
    {
        
    }

    private WaiterEntity(string waiterName)
    {
        Name = waiterName;
        WaiterId = Guid.NewGuid();
    }


    public static WaiterEntity Create(string waiterName)
    {
        return new WaiterEntity(waiterName);
    }
}