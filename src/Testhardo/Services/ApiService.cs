using System.Net.Http.Json;

namespace Testhardo.Services;

public interface IApiService
{
    Task<T?> GetAsync<T>(string url, CancellationToken cancellationToken = default);
    Task PostAsync<K>(string url, K request, CancellationToken cancellationToken = default);
    Task<T?> PostAsync<T, K>(string url, K request, CancellationToken cancellationToken = default);
    Task PatchAsync<K>(string url, K request, CancellationToken cancellationToken = default);
    Task<T?> PatchAsync<T, K>(string url, K request, CancellationToken cancellationToken = default);
    Task DeleteAsync(string url, CancellationToken cancellationToken = default);
}

public class ApiService : IApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<T?> GetAsync<T>(string url, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient();

        return await client.GetFromJsonAsync<T>(url, cancellationToken);
    }

    public async Task<T?> PostAsync<T, K>(string url, K request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.PostAsJsonAsync<K>(url, request, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
    }

    public async Task PostAsync<K>(string url, K request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.PostAsJsonAsync<K>(url, request, cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    public async Task<T?> PatchAsync<T, K>(string url, K request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.PatchAsJsonAsync<K>(url, request, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
    }

    public async Task PatchAsync<K>(string url, K request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.PatchAsJsonAsync<K>(url, request, cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(string url, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.DeleteAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}
