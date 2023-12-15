namespace CloudMT.PublicAPI.Example.Models;

using System.Collections.Generic;

public sealed record ItemKeysResult
{
    public required List<int> Keys { get; init; }
}