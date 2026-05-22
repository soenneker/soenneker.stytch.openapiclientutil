using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Stytch.HttpClients.Registrars;
using Soenneker.Stytch.OpenApiClientUtil.Abstract;

namespace Soenneker.Stytch.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class StytchOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="StytchOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddStytchOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddStytchOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IStytchOpenApiClientUtil, StytchOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="StytchOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddStytchOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddStytchOpenApiHttpClientAsSingleton()
                .TryAddScoped<IStytchOpenApiClientUtil, StytchOpenApiClientUtil>();

        return services;
    }
}
