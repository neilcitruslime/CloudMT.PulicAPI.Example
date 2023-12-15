namespace CloudMT.PublicAPI.Example.Models;

using System;

public sealed record AuthResult
{
    public required string Token { get; init; }
    public required DateTime DateAuthorised { get; init; }
}