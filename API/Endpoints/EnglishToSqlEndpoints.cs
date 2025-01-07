using Application.EnglishToSql;
using Application.OpenAi.Messages.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints;

public class EnglishToSqlEndpoints : IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("EnglishToSql")
            .MediateGet<EnglishToSqlRequest, List<string>>("/");
    }
}