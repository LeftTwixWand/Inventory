namespace BuildingBlocks.Domain.ValueObjects;

/// <summary>
/// Marks, that current property or field will be ignored in ValueObject comparison.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class IgnoreMemberAttribute : Attribute
{
}