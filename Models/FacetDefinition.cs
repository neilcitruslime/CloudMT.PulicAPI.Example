namespace CloudMT.PublicAPI.Example.Models;

using System.Collections.Generic;

public sealed record FacetDefinition
{
    public required int? Id { get; init; }

    public List<BrowseFilterDefinition>? BrowseFilters { get; init; }
}