using Application.OpenAi.Threads;
using Application.OpenAi.Threads.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints.OpenAi;

public class ThreadEndpoints :  IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Threads")
            .MediatePost<CreateThreadRequest, ThreadDto>("/")
            .MediateGet<GetThreadRequest, ThreadDto>("/{threadId}");
    }
}