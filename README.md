[![](https://img.shields.io/nuget/v/soenneker.stytch.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.stytch.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.stytch.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.stytch.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.stytch.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.stytch.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.stytch.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.stytch.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Stytch.OpenApiClientUtil

Provides a lazily initialized `StytchOpenApiClient` backed by the authenticated, cached Stytch `HttpClient`.

## Installation

```bash
dotnet add package Soenneker.Stytch.OpenApiClientUtil
```

## Configuration

```json
{
  "Stytch": {
    "ProjectId": "project-test-...",
    "Secret": "secret-test-...",
    "ClientBaseUrl": "https://test.stytch.com"
  }
}
```

## Usage

```csharp
using Soenneker.Stytch.OpenApiClient;
using Soenneker.Stytch.OpenApiClient.Models;
using Soenneker.Stytch.OpenApiClientUtil.Abstract;
using Soenneker.Stytch.OpenApiClientUtil.Registrars;

services.AddStytchOpenApiClientUtilAsScoped();

StytchOpenApiClient client = await stytchClientUtil.Get(cancellationToken);
ApiUserV1GetResponse? response = await client.V1.Users["user-test-..."].GetAsync(
    cancellationToken: cancellationToken);
```

The scoped registration uses a singleton HTTP provider. Disposing the scoped utility releases its generated client wrapper without removing the shared authenticated `HttpClient`; the HTTP provider disposes that client at application shutdown.
