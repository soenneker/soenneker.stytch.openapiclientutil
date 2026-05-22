using Soenneker.Stytch.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Stytch.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class StytchOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IStytchOpenApiClientUtil _openapiclientutil;

    public StytchOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IStytchOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
