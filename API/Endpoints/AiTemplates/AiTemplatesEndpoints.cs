using System.Dynamic;
using Application.AiTemplates;
using Application.AiTemplates.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints.AiTemplates;

public class AiTemplatesEndpoints : IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("AiTemplates")
            .MediatePost<ValidateEnglishToSqlRequest, EnglishToSqlDto>("")
            .MediatePost<ExecuteSqlRequest, List<ExpandoObject>>("/ExecuteSql");
    }
}