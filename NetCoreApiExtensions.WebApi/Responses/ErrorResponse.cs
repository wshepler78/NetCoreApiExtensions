namespace NetCoreApiExtensions.WebApi.Responses;

/// <summary>
/// Generic API response error wrapper
/// </summary>
/// <typeparam name="TErrors">The type of the error.</typeparam>
/// <seealso cref="ServerResponse" />
/// <seealso cref="IApiResponse{TData,TError}"/>
public class ErrorResponse<TErrors> : ServerResponse, IApiResponse<string?, TErrors?>
{
    private ErrorResponse(TErrors errors)
    {
        Errors = errors;
    }

    /// <summary>
    /// Creates the specified data.
    /// </summary>
    /// <param name="errors">The errors.</param>
    /// <returns></returns>
    public static ErrorResponse<TErrors> Create(TErrors errors)
    {
        return new ErrorResponse<TErrors>(errors);
    }

    /// <inheritdoc />
    string? IApiResponse<string?, TErrors?>.Data => null;

    /// <inheritdoc />
    public TErrors? Errors { get; }
}