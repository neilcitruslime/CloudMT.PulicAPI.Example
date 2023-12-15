namespace CloudMT.PublicAPI.Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed record ImageResult
{
    public required string Url { get; init; }
}