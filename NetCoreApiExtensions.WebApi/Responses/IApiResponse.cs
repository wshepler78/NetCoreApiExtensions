namespace NetCoreApiExtensions.WebApi.Responses;

/// <summary>
/// A basic API response
/// </summary>
/// <typeparam name="TData">The type of the data.</typeparam>
/// <typeparam name="TError">The type of the error.</typeparam>
public interface IApiResponse<out TData, out TError> : IServerResponse
{
    /// <summary>Gets or sets the data.</summary>
    /// <value>The data.</value>
    TData Data { get; }

    /// <summary>
    /// Gets or sets the errors.
    /// </summary>
    TError Errors { get; }
}