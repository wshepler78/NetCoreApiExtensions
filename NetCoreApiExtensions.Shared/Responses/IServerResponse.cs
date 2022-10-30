using System;

namespace NetCoreApiExtensions.Shared.Responses;

/// <summary>
/// Basic Server Response Definition
/// </summary>
public interface IServerResponse
{
    /// <summary>
    /// Gets the correlation identifier.
    /// </summary>
    Guid CorrelationId { get; }

    /// <summary>
    /// Gets the response time.
    /// </summary>
    DateTime ResponseTime { get; }
}