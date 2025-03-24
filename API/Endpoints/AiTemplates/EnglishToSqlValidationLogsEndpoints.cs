using Application.AiTemplates;
using Application.AiTemplates.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints.AiTemplates;

public class EnglishToSqlValidationLogsEndpoints : IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("EnglishToSqlValidationLogs")
            .MediatePost<LogEnglishToSqlValidationRequest, bool>("/")
            .MediateGet<GetEnglishToSqlValidationLogsRequest, IEnumerable<EnglishToSqlValidationLogDto>>("/");
    }
}