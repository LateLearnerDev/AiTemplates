using System.Text.Json;
using Application.AiTemplates.Dtos;
using Application.AzureOpenAi.Completions;
using Application.Common.Enums;
using Application.Common.Extensions;
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

public class SubmitEnglishToSqlRequestHandler(ISender sender) : IRequestHandler<SubmitEnglishToSqlRequest, EnglishToSqlDto>
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
                var result = await sender.Send(new CreateAzureCompletionRequest
                {
                    SystemPrompt = GenerateSqlSchemaSystemPrompt(simpleSchema),
                    UserPrompt = request.UserQuery
                });
                // var options = new JsonSerializerOptions
                // {
                //     Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Prevents escaping
                // };
                return new EnglishToSqlDto
                {
                    // Response = JsonSerializer.Serialize(new { query = result.Content.First().Text.RemoveMarkdownNewLinesAndSpaces() }, options),
                    Response = result.Content.First().Text,
                    TokenCost = result.Usage.TotalTokenCount,
                    TimeTaken = 1
                };
                break;
            case SchemaSelection.ComplexSchema:
                return new EnglishToSqlDto
                {
                    Response = "Complex schema not yet supported"
                };
                break;
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
                   $"Only ever return the sql unless you don't understand the request. Please also add double quotes " +
                   $"to all table and column names";
        }
    }
}