namespace BrighTown.Models;

public class ServiceResponse<T> : HttpResponseMessage
{
    public T? Data { get; set; }

    public bool Success { get; set; } = true;

    public string Message { get; set; } = string.Empty;
}