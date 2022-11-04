namespace NetCoreApiExtensions.Shared.Responses;

/// <summary>
/// Generic API response Data wrapper
/// </summary>
/// <typeparam name="TData">The type of the data.</typeparam>
/// <seealso cref="IApiResponse{TData,TError}"/>
public class DataResponse<TData> : ServerResponse, IApiResponse<TData, string>
{
    public DataResponse()
    {

    }

    private DataResponse(TData data)
    {
        Data = data;
    }

    /// <summary>
    /// Creates the specified data.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static DataResponse<TData> Create(TData data)
    {
        return new DataResponse<TData>(data);
    }

    /// <inheritdoc />
    public TData Data { get; set; }

    string IApiResponse<TData, string>.Errors => null;
}