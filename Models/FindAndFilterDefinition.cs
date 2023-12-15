namespace CloudMT.PublicAPI.Example.Models;

using System.Collections.Generic;

public sealed record FindAndFilterDefinition
{
    public required FacetDefinition Department { get; init; }

    public required FacetDefinition Activity { get; init; }

    public required FacetDefinition Material { get; init; }

    public required FacetDefinition ItemGroup { get; init; }

    public required List<CollectionDefinition> Collections { get; init; }
}