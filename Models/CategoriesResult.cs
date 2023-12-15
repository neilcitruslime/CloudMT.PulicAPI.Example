namespace CloudMT.PublicAPI.Example.Models;

using System.Collections.Generic;

public sealed record CategoriesResult
{
    public required List<CategoryResult> Categories { get; init; }
}