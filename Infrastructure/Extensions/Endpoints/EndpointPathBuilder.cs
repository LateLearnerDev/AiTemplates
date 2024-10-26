using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Infrastructure.Extensions.Endpoints;

public static class EndpointPathBuilder
{
    private static string BasePath { get; set; } = "";

    public static void UseBasePath(this IEndpointRouteBuilder endpointRoute,
        string basePath)
    {
        BasePath = basePath;
    }

    public static RouteGroupBuilder BuildPath(this IEndpointRouteBuilder endpointRoute, string prefix)
    {
        return endpointRoute.MapGroup($"{BasePath}{prefix}").WithTags(prefix);
    }
}