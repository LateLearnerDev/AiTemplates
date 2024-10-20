namespace API.Infrastructure.Extensions;

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