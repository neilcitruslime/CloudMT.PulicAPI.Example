namespace CloudMT.PublicAPI.Example.Models;

public sealed record AuthRequest
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}