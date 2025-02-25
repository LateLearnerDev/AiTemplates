using System.Diagnostics;
using System.Text.Json;
using Application.AiTemplates.Dtos;
using Application.AzureOpenAi.Completions;
using Application.Common.Enums;
using Application.Common.Extensions;
using Application.QueryRunner;
using Application.SchemaSummariser;
using CommunityToolkit.Diagnostics;
using MediatR;

namespace Application.AiTemplates;

public class SubmitEnglishToSqlRequest : IRequest<EnglishToSqlDto>
{
    public AiServiceSelection AiServiceSelection { get; set; }
    public SchemaSelection SchemaSelection { get; set; }
    public required string UserQuery { get; set; }
    public string? CustomSchema { get; set; }
}

public class SubmitEnglishToSqlRequestHandler(ISender sender, IQueryRunnerService queryRunnerService) : IRequestHandler<SubmitEnglishToSqlRequest, EnglishToSqlDto>
{
    public async Task<EnglishToSqlDto> Handle(SubmitEnglishToSqlRequest request, CancellationToken cancellationToken)
    {
        Guard.IsNotEmpty(request.UserQuery);
        
        return request.AiServiceSelection switch
        {
            AiServiceSelection.AzureOpenAiGpt4oMini => await SelectSchemaAndSubmit(request),
            AiServiceSelection.LocallyHosted => new EnglishToSqlDto
            {
                Response = "Locally hosted service not yet supported"
            },
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    private async Task<EnglishToSqlDto> SelectSchemaAndSubmit(SubmitEnglishToSqlRequest request)
    {
        switch (request.SchemaSelection)
        {
            case SchemaSelection.SimpleSchema:
                var simpleSchema = await sender.Send(new GetSummarizedSchemaRequest());
                var stopwatch = Stopwatch.StartNew();
                var result = await sender.Send(new CreateAzureCompletionRequest
                {
                    SystemPrompt = GenerateSqlSchemaSystemPrompt(simpleSchema),
                    UserPrompt = request.UserQuery
                });
                stopwatch.Stop();
                
                var response = result.Content.First().Text;
                var queryValidation = await queryRunnerService.ValidateQuery(response);
                var elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                return new EnglishToSqlDto
                {
                    Response = response,
                    TokenCost = result.Usage.TotalTokenCount,
                    TimeTaken = Math.Round(elapsedSeconds, 2),
                    Success = queryValidation.Success,
                    ValidationMessage = queryValidation.ExexutionPlan
                };
            case SchemaSelection.ComplexSchema:
                return new EnglishToSqlDto
                {
                    Response = "Complex schema not yet supported"
                };
            case SchemaSelection.CustomSchema:
                return new EnglishToSqlDto
                {
                    Response = "Custom schema not yet supported"
                };
            default:
                throw new ArgumentOutOfRangeException();
        }

        string GenerateSqlSchemaSystemPrompt(string schema)
        {
            return $"Assistant that converts english to sql upon user request with the following schema: {schema}. " +
                   $"Only ever return the sql unless you don't understand the request. Please assume the user would rather have names " +
                   $"instead of ids, unless specified otherwise.";
        }
    }
}