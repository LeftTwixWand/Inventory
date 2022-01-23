using System.Reflection;
using BuildingBlocks.Domain.BusinessRules;

namespace BuildingBlocks.Domain.ValueObjects;

/// <summary>
/// Abstraction for value objects with built-in fields/properties comparison.
/// <para><see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects">Read more about value objects</see>.</para>
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    private List<PropertyInfo> _properties = new();

    private List<FieldInfo> _fields = new();

    public static bool operator ==(ValueObject obj1, ValueObject obj2)
    {
        return obj1.Equals(obj2);
    }

    public static bool operator !=(ValueObject obj1, ValueObject obj2)
    {
        return !(obj1 == obj2);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        // allow overflow
        unchecked
        {
            var hash = 17;
            foreach (var prop in GetProperties())
            {
                var value = prop.GetValue(this, null);
                hash = HashValue(hash, value);
            }

            foreach (var field in GetFields())
            {
                var value = field.GetValue(this);
                hash = HashValue(hash, value);
            }

            return hash;
        }
    }

    /// <summary>
    /// <inheritdoc cref="Equals(object)"/>
    /// </summary>
    /// <param name="obj">ValueObject to compare.</param>
    /// <returns>True, if object are equals.</returns>
    public bool Equals(ValueObject? obj)
    {
        return Equals(obj as object);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return GetProperties().All(p => PropertiesAreEqual(obj, p))
            && GetFields().All(f => FieldsAreEqual(obj, f));
    }

    /// <summary>
    /// Checks business rule for ValueObject.
    /// </summary>
    /// <param name="rule">Business rule to check.</param>
    /// <exception cref="BusinessRuleValidationException">Exception can be thrown on invalid business rule.</exception>
    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    private static int HashValue(int seed, object? value)
    {
        var currentHash = value?.GetHashCode() ?? 0;

        return (seed * 23) + currentHash;
    }

    private bool PropertiesAreEqual(object obj, PropertyInfo prop)
    {
        return Equals(prop.GetValue(this, null), prop.GetValue(obj, null));
    }

    private bool FieldsAreEqual(object obj, FieldInfo field)
    {
        return Equals(field.GetValue(this), field.GetValue(obj));
    }

    private IEnumerable<PropertyInfo> GetProperties()
    {
        if (_properties == null || _properties.Count < 1)
        {
            _properties = GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => !p.IsDefined(typeof(IgnoreMemberAttribute)))
                .ToList();
        }

        return _properties;
    }

    private IEnumerable<FieldInfo> GetFields()
    {
        if (_fields == null || _fields.Count < 1)
        {
            _fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => !p.IsDefined(typeof(IgnoreMemberAttribute)))
                .ToList();
        }

        return _fields;
    }
}