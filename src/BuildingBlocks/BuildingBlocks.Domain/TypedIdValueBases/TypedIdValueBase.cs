namespace BuildingBlocks.Domain.TypedIdValueBases;

public record TypedIdValueBase<T>(T Value)
    where T : notnull;