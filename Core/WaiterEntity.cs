using Core.Base.Entity;

namespace Core;

public class WaiterEntity: EntityBase
{
    public WaiterId WaiterId { get; set; }
    public string Name { get; set; }

    public string ExternalId { get; set; }
    
    public WaiterEntity()
    {
        
    }

    private WaiterEntity(string waiterName, string waiterExternalId)
    {
        Name = waiterName;
        WaiterId = Guid.NewGuid();
        ExternalId = waiterExternalId;
    }


    public static WaiterEntity Create(string waiterName, string waiterExternalId)
    {
        return new WaiterEntity(waiterName, waiterExternalId);
    }
}