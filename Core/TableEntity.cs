using Core.Base.Entity;

namespace Core;

public class TableEntity: EntityBase
{
    public TableId TableId { get; set; }
    public string Name { get; private set; }
    public bool IsAvailable { get; private set; }

    private TableEntity(string tableName)
    {
        Name = tableName;
        TableId = Guid.NewGuid();
    }

    public static TableEntity Create(string tableName)
    {
        return new TableEntity(tableName);
    }
    
}