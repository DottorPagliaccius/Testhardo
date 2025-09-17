namespace Testhardo.Services;

public interface IApiService
{
    Task<ServiceResponse> GetAsync(string url, TimeSpan timeout = default, CancellationToken cancellationToken = default);
    Task<ServiceResponse> PostAsync(string url, string jsonRequest, TimeSpan timeout = default, CancellationToken cancellationToken = default);
    Task<ServiceResponse> PutAsync(string url, string jsonRequest, TimeSpan timeout = default, CancellationToken cancellationToken = default);
    Task<ServiceResponse> PatchAsync(string url, string jsonRequest, TimeSpan timeout = default, CancellationToken cancellationToken = default);
    Task<ServiceResponse> DeleteAsync(string url, TimeSpan timeout = default, CancellationToken cancellationToken = default);
}

public class ApiService : IApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ServiceResponse> GetAsync(string url, TimeSpan timeout = default, CancellationToken cancellationToken = default)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();

            client.Timeout = timeout;

            var response = await client.GetAsync(url, cancellationToken);

            return new ServiceResponse
            {
                StatusCode = (int)response.StatusCode,
                JsonResponse = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken)
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse { Exception = ex };
        }
    }

    public async Task<ServiceResponse> PostAsync(string url, string jsonRequest, TimeSpan timeout = default, CancellationToken cancellationToken = default)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();

            client.Timeout = timeout;

            var response = await client.PostAsync(url, new StringContent(jsonRequest), cancellationToken);

            return new ServiceResponse
            {
                StatusCode = (int)response.StatusCode,
                JsonResponse = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken)
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse { Exception = ex };
        }
    }

    public async Task<ServiceResponse> PutAsync(string url, string jsonRequest, TimeSpan timeout = default, CancellationToken cancellationToken = default)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();

            client.Timeout = timeout;

            var response = await client.PutAsync(url, new StringContent(jsonRequest), cancellationToken);

            return new ServiceResponse
            {
                StatusCode = (int)response.StatusCode,
                JsonResponse = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken)
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse { Exception = ex };
        }
    }

    public async Task<ServiceResponse> PatchAsync(string url, string jsonRequest, TimeSpan timeout = default, CancellationToken cancellationToken = default)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();

            client.Timeout = timeout;

            var response = await client.PatchAsync(url, new StringContent(jsonRequest), cancellationToken);

            return new ServiceResponse
            {
                StatusCode = (int)response.StatusCode,
                JsonResponse = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken)
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse { Exception = ex };
        }
    }

    public async Task<ServiceResponse> DeleteAsync(string url, TimeSpan timeout = default, CancellationToken cancellationToken = default)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();

            client.Timeout = timeout;

            var response = await client.DeleteAsync(url, cancellationToken);

            return new ServiceResponse
            {
                StatusCode = (int)response.StatusCode,
                JsonResponse = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken)
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse { Exception = ex };
        }
    }
}
