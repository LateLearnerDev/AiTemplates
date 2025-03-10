using System.Diagnostics;
using Application.AiTemplates.Dtos;
using Application.AzureOpenAi;
using Application.Common.Enums;
using Application.Common.Extensions;
using Application.QueryRunner;
using Application.SchemaSummariser;
using CommunityToolkit.Diagnostics;
using MediatR;

namespace Application.AiTemplates;

public class ValidateEnglishToSqlRequest : IRequest<EnglishToSqlDto>
{
    public required AiServiceSelection AiServiceSelection { get; set; }
    public required SchemaSelection SchemaSelection { get; set; }
    public required string UserQuery { get; set; }
    public string? CustomSchema { get; set; }
}

public class ValidateEnglishToSqlRequestHandler(ISender sender, IQueryRunnerService queryRunnerService, IAzureOpenAiClient azureOpenAiClient) : IRequestHandler<ValidateEnglishToSqlRequest, EnglishToSqlDto>
{
    public async Task<EnglishToSqlDto> Handle(ValidateEnglishToSqlRequest request, CancellationToken cancellationToken)
    {
        Guard.IsNotEmpty(request.UserQuery);
        
        return request.AiServiceSelection switch
        {
            AiServiceSelection.AzureOpenAiGpt4oMini => await SelectSchemaAndSubmitAsync(request),
            AiServiceSelection.LocallyHosted => new EnglishToSqlDto
            {
                Response = "Locally hosted service not yet supported"
            },
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    private async Task<EnglishToSqlDto> SelectSchemaAndSubmitAsync(ValidateEnglishToSqlRequest request)
    {
        return request.SchemaSelection switch
        {
            SchemaSelection.SimpleSchema => await HandleSimpleSchemaAsync(request),
            SchemaSelection.ComplexSchema => HandleComplexSchemaAsync(),
            SchemaSelection.CustomSchema => HandleCustomSchemaAsync(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static EnglishToSqlDto HandleCustomSchemaAsync()
    {
        return new EnglishToSqlDto
        {
            Response = "Custom schema not yet supported"
        };
    }

    private static EnglishToSqlDto HandleComplexSchemaAsync()
    {
        return new EnglishToSqlDto
        {
            Response = "Complex schema not yet supported"
        };
    }

    private async Task<EnglishToSqlDto> HandleSimpleSchemaAsync(ValidateEnglishToSqlRequest request)
    {
        var simpleSchema = await sender.Send(new GetSummarizedSchemaRequest());

        var stopwatch = Stopwatch.StartNew();
        var completion = await azureOpenAiClient.GetChatCompletionAsync(GenerateSqlSchemaSystemPrompt(simpleSchema), request.UserQuery);
        stopwatch.Stop();

        var response = completion.Content
            .FirstOrDefault()
            ?.Text
            .RemoveMarkdownNewLinesAndSpaces() ?? string.Empty;
        var queryValidation = await queryRunnerService.ValidateQueryAsync(response);

        return new EnglishToSqlDto
        {
            Response = response,
            TokenCost = completion.Usage.TotalTokenCount,
            TimeTaken = Math.Round(stopwatch.Elapsed.TotalSeconds, 2),
            Success = queryValidation.Success,
            ValidationMessage = queryValidation.ExexutionPlan
        };
    }
    
    private static string GenerateSqlSchemaSystemPrompt(string schema)
    {
        return $"Assistant that converts english to sql for SQL Server upon user request with the following schema: {schema}. " +
               $"Only ever return the sql, unless you don't understand the request. Please assume the user would rather have names " +
               $"instead of ids, unless specified otherwise.";
    }
}