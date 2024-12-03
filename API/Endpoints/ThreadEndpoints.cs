using Application.Threads;
using Application.Threads.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints;

public class ThreadEndpoints :  IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Threads")
            .MediatePost<CreateThreadRequest, ThreadDto>("/")
            .MediateGet<GetThreadRequest, ThreadDto>("/{threadId}");
    }
}