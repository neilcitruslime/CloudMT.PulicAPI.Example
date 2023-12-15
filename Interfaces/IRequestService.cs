namespace CloudMT.PublicAPI.Example.Interfaces;

using CloudMT.PublicAPI.Example.Models;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

internal interface IRequestService
{
    Task<string?> PerformAuthAsync(AuthRequest authRequest, CancellationToken cancellationToken);

    Task<List<int>?> GetItemKeysAsync(string token, CancellationToken cancellationToken);

    Task<List<ItemResult>?> GetItemsAsync(string token, ItemsRequest itemsRequest, CancellationToken cancellationToken);

    Task<List<CategoryResult>?> GetCategoriesAsync(string token, CancellationToken cancellationToken);
}