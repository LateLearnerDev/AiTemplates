using Microsoft.AspNetCore.Routing;

namespace Infrastructure.Extensions.Endpoints;

public interface IEndPointMapper
{
    void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder);
}