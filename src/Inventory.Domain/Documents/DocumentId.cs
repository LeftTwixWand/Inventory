namespace Inventory.Domain.Documents;

public readonly record struct DocumentId(Guid Value)
{
    public bool IsEmpty => Value == Guid.Empty;
}