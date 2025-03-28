using System.Reflection;
using Infrastructure.Extensions.Endpoints;

namespace API;

public static class StartupEndpoints
{
    public static void UseEndpoints(this IApplicationBuilder app, Assembly assembly)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
            endpoints.MapControllers();

            var endpointMappers = assembly.GetTypes()
                .Where(type =>
                    typeof(IEndPointMapper).IsAssignableFrom(type) && type is { IsInterface: false, IsAbstract: false })
                .Select(Activator.CreateInstance)
                .Cast<IEndPointMapper>();

            foreach (var endpointMapper in endpointMappers)
                endpointMapper.MapEndpoints(endpoints);
        });
    }
}