using System;
using System.Xml.Linq;

namespace NetCoreApiExtensions.WebApi.Responses;

/// <inheritdoc />
public abstract class ServerResponse : IServerResponse
{
    /// <inheritdoc />
    public Guid CorrelationId { get; } = Guid.NewGuid();

    /// <inheritdoc />
    public DateTime ResponseTime => DateTime.UtcNow;
}