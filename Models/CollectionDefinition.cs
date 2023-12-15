namespace CloudMT.PublicAPI.Example.Models;

public sealed record CollectionDefinition
{
    public required int Id { get; init; }

    public required int Order { get; init; }
}