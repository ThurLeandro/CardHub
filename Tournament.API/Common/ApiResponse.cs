public class ApiResponse<T>
{
    public bool Success { get; }
    public T? Data { get; }
    public List<string> Errors { get; }

    private ApiResponse(bool success, T? data, List<string> errors)
    {
        Success = success;
        Data = data;
        Errors = errors;
    }

    public static ApiResponse<T> Ok(T data)
        => new(true, data, []);

    public static ApiResponse<T> Fail(params string[] errors)
        => new(false, default, errors.ToList());
}
