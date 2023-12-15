namespace CloudMT.PublicAPI.Example.Models;

using System.Collections.Generic;

public sealed record ItemsRequest
{
    public required List<int> Keys { get; init; }
}