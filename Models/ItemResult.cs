namespace CloudMT.PublicAPI.Example.Models;

using System.Collections.Generic;
using System;

public sealed record ItemResult
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public required string LookupCode { get; init; }

    public required string PageTitle { get; init; }

    public required string ShortDescription { get; init; }

    public required string LongDescription { get; init; }

    public required string Gender { get; init; }

    public required string Age { get; init; }

    public required int? PrimaryCategory { get; init; }

    public required string GoogleCategory { get; init; }

    public required string Colour { get; init; }

    public required string TechnicalInformation { get; init; }

    public required string Range { get; init; }

    public required string SizeInformation { get; init; }

    public required string AdditionalDescription { get; init; }

    public required string Video { get; init; }

    public required string BuyersGuide { get; init; }

    public required decimal? Length { get; init; }

    public required decimal? Width { get; init; }

    public required decimal? Height { get; init; }

    public required bool? FindAndFilterPriority { get; init; }

    public required FindAndFilterDefinition FindAndFilterDefinition { get; init; }

    public required bool? BlockCoupons { get; init; }

    public required bool? BlockFinance { get; init; }

    public required bool? BlockSimStock { get; init; }

    public required bool? DeliveryChargesApply { get; init; }

    public required int? DeliveryDelay { get; init; }

    public required string DeliveryDelayMessage { get; init; }

    public required bool? ClickAndCollectOnly { get; init; }

    public required bool? TrackedStock { get; init; }

    public required bool? BlockPickUp { get; init; }

    public required bool? PreLaunch { get; init; }

    public required DateTime? PreLaunchDate { get; init; }

    public required bool? Active { get; init; }

    public required List<int> SiteExclusions { get; init; }

    public required List<ImageResult> Images { get; init; }
}