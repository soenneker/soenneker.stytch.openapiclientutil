using Soenneker.Stytch.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Stytch.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IStytchOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<StytchOpenApiClient> Get(CancellationToken cancellationToken = default);
}
