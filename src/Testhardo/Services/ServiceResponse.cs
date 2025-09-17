namespace Testhardo.Services;

public class ServiceResponse
{
    public int? StatusCode { get; set; }
    public string? JsonResponse { get; set; }
    public Exception? Exception { get; set; }
}
