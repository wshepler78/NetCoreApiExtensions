using System;

namespace NetCoreApiExtensions.Shared.Responses;

/// <inheritdoc />
public abstract class ServerResponse : IServerResponse
{
    /// <inheritdoc />
    public Guid CorrelationId { get; } = Guid.NewGuid();

    /// <inheritdoc />
    public DateTime ResponseTime => DateTime.UtcNow;
}