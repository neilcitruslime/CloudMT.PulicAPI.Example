namespace CloudMT.PublicAPI.Example.Models;

public sealed record CategoryResult
{
    public int Id { get; init; }

    public required string Path { get; init; }
}