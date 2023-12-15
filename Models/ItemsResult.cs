namespace CloudMT.PublicAPI.Example.Models;

using System.Collections.Generic;

public sealed record ItemsResult
{
    public required List<ItemResult> Items { get; init; }
}