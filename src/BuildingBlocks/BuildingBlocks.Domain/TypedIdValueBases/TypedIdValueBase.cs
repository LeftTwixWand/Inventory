namespace BuildingBlocks.Domain.TypedIdValueBases;

public abstract class TypedIdValueBase : IEquatable<TypedIdValueBase>
{
    protected TypedIdValueBase(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidOperationException("Id value cannot be empty!");
        }

        Value = value;
    }

    public Guid Value { get; }

    public static bool operator ==(TypedIdValueBase obj1, TypedIdValueBase obj2)
    {
        if (object.Equals(obj1, null))
        {
            if (object.Equals(obj2, null))
            {
                return true;
            }

            return false;
        }

        return obj1.Equals(obj2);
    }

    public static bool operator !=(TypedIdValueBase x, TypedIdValueBase y)
    {
        return !(x == y);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        return obj is TypedIdValueBase other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public bool Equals(TypedIdValueBase? other)
    {
        return this.Value == other?.Value;
    }
}