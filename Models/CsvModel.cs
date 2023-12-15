// <copyright file="CsvModel.cs" company="CitrusLime Ltd">
// Copyright (c) CitrusLime Ltd. All rights reserved.
// </copyright>

namespace CloudMT.PublicAPI.Example.Models;

public class CsvModel
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string LookupCode { get; init; } = string.Empty;
    
    public bool Active { get; init; }
}