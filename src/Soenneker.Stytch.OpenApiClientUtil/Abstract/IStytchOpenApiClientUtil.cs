using Soenneker.Stytch.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Stytch.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily initialized Stytch OpenAPI client backed by the shared authenticated HTTP client.
/// </summary>
public interface IStytchOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Releases the generated client wrapper owned by this utility without disposing the shared HTTP provider.
    /// </summary>
    new void Dispose();

    /// <summary>
    /// Asynchronously releases the generated client wrapper owned by this utility without disposing the shared HTTP provider.
    /// </summary>
    new ValueTask DisposeAsync();

    /// <summary>
    /// Gets the cached Stytch OpenAPI client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<StytchOpenApiClient> Get(CancellationToken cancellationToken = default);
}
