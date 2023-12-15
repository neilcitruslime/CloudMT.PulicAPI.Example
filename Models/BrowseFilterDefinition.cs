namespace CloudMT.PublicAPI.Example.Models;

public sealed record BrowseFilterDefinition
{
    public int? Id { get; init; }

    public int Level { get; init; }
}