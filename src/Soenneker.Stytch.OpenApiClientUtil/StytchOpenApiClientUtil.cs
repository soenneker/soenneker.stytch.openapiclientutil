using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Stytch.HttpClients.Abstract;
using Soenneker.Stytch.OpenApiClientUtil.Abstract;
using Soenneker.Stytch.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Stytch.OpenApiClientUtil;

public sealed class StytchOpenApiClientUtil : IStytchOpenApiClientUtil
{
    private readonly AsyncSingleton<StytchOpenApiClient> _client;

    public StytchOpenApiClientUtil(IStytchOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<StytchOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new StytchOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<StytchOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
