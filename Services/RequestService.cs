namespace CloudMT.PublicAPI.Example.Services;

using CloudMT.PublicAPI.Example.Interfaces;
using CloudMT.PublicAPI.Example.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

internal sealed class RequestService(HttpClient httpClient) : IRequestService
{
    private const string URL = "https://cloudmt.citruslime.com/api/public";

    private readonly HttpClient httpClient = httpClient;

    public async Task<string?> PerformAuthAsync(AuthRequest authRequest, CancellationToken cancellationToken)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, $"{URL}/auth");

        request.Content = JsonContent.Create(authRequest);

        using HttpResponseMessage response = await this.httpClient.SendAsync(request, cancellationToken);

        AuthResult? result = null;

        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadFromJsonAsync<AuthResult>(cancellationToken);
        }

        return result?.Token;
    }

    public async Task<List<int>?> GetItemKeysAsync(string token, CancellationToken cancellationToken)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"{URL}/item");

        request.Headers.Authorization = new("Bearer", token);

        using HttpResponseMessage response = await this.httpClient.SendAsync(request, cancellationToken);

        ItemKeysResult? result = null;

        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadFromJsonAsync<ItemKeysResult>(cancellationToken);
        }

        return result?.Keys;
    }

    public async Task<List<ItemResult>?> GetItemsAsync(string token, ItemsRequest itemsRequest, CancellationToken cancellationToken)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, $"{URL}/item/detail/keys");

        request.Headers.Authorization = new("Bearer", token);
        request.Content = JsonContent.Create(itemsRequest);

        using HttpResponseMessage response = await this.httpClient.SendAsync(request, cancellationToken);

        ItemsResult? result = null;

        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadFromJsonAsync<ItemsResult>(cancellationToken);
        }

        return result?.Items;
    }

    public async Task<List<CategoryResult>?> GetCategoriesAsync(string token, CancellationToken cancellationToken)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, $"{URL}/category");

        request.Headers.Authorization = new("Bearer", token);

        using HttpResponseMessage response = await this.httpClient.SendAsync(request, cancellationToken);

        CategoriesResult? result = null;

        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadFromJsonAsync<CategoriesResult>(cancellationToken);
        }

        return result?.Categories;
    }
}