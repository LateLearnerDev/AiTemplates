using Application.Gyms;
using Application.Gyms.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints;

public class GymEndpoints : IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Gyms")
            .MediateGet<GetGymsRequest, IEnumerable<GymDto>>("/");
    }
}