namespace CinemaApi.Services;
public enum ServiceErrorKind
{
    None,
    Validation,
    NotFound,
    Conflict
}

public sealed class ServiceResult<T>
{
    private ServiceResult(T? value, ServiceErrorKind error, string? message)
    {
        Value = value;
        Error = error;
        Message = message;
    }

    public T? Value { get; }
    public ServiceErrorKind Error { get; }
    public string? Message { get; }
    public bool IsSuccess => Error == ServiceErrorKind.None;

    public static ServiceResult<T> Success(T value)
        => new(value, ServiceErrorKind.None, null);

    public static ServiceResult<T> Fail(ServiceErrorKind error, string message)
        => new(default, error, message);
}