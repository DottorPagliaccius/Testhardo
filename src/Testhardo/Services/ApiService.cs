using System.Text;

namespace Testhardo.Services;

public interface IApiService
{
    Task<ServiceResponse> SendAsync(HttpMethod method, string url, string? jsonRequest = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default);
}

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceResponse> SendAsync(HttpMethod method, string url, string? jsonRequest = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default)
    {
        try
        {
            using var timeoutCts = timeout.HasValue ? new CancellationTokenSource(timeout.Value) : null;

            using var linkedCts = timeoutCts != null ? CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token) : null;

            var effectiveToken = linkedCts?.Token ?? cancellationToken;

            using var request = new HttpRequestMessage(method, url);

            if (!string.IsNullOrWhiteSpace(jsonRequest))
                request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, effectiveToken);

            var content = await response.Content.ReadAsStringAsync(effectiveToken);

            return new ServiceResponse
            {
                StatusCode = (int)response.StatusCode,
                JsonResponse = content
            };
        }
        catch (OperationCanceledException) when (timeout.HasValue)
        {
            return new ServiceResponse
            {
                Exception = new TimeoutException($"Request timed out after {timeout.Value.TotalSeconds} seconds")
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse { Exception = ex };
        }
    }
}