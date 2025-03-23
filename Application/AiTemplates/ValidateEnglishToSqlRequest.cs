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
        var isValid = await ValidateUserQueryAsync(request.UserQuery);
        if (!isValid)
        {
            return new EnglishToSqlDto
            {
                Response = "I couldn't understand your request. Please try again with a clearer question.",
                Success = false,
                ValidationMessage = "Query was deemed invalid."
            };
        }
        
        var simpleSchema = await sender.Send(new GetSummarizedSchemaRequest());

        var stopwatch = Stopwatch.StartNew();
        var completion = await azureOpenAiClient.GetChatCompletionAsync(GenerateSqlSchemaSystemPrompt(simpleSchema), request.UserQuery);
        stopwatch.Stop();

        var response = completion.Content
            .FirstOrDefault()
            ?.Text
            .RemoveMarkdownNewLinesAndSpaces() ?? string.Empty;
        var queryValidation = await queryRunnerService.ValidateSqlQueryAsync(response);

        return new EnglishToSqlDto
        {
            Response = response,
            TokenCost = completion.Usage.TotalTokenCount,
            TimeTaken = Math.Round(stopwatch.Elapsed.TotalSeconds, 2),
            Success = queryValidation.Success,
            ValidationMessage = queryValidation.ExexutionPlan
        };
    }

    private async Task<bool> ValidateUserQueryAsync(string userQuery)
    {
        const string validatorPrompt = "Determine if the following user request is a valid and meaningful data request " +
                                       "based on gyms, gym equipment, workouts, cycles, users, exercises, sets. " +
                                       "Respond with only 'VALID' or 'INVALID'. Do not explain your reasoning.";

        var completion = await azureOpenAiClient.GetChatCompletionAsync(validatorPrompt, userQuery);

        var response = completion.Content.FirstOrDefault()?.Text?.Trim().ToUpper() ?? "INVALID";

        return response == "VALID";
    }
    
    private static string GenerateSqlSchemaSystemPrompt(string schema)
    {
        return $"You are an AI assistant that retrieves data from a structured database. " +
               $"You generate SQL queries for SQL Server based on user requests, following this schema: {schema}. " +
               $"Your primary job is to return SQL queries when possible (return the sql ONLY, with no comments). " +
               $"Never engage in conversations that don't involve the data in the database." +
               $"However, if a request is unclear, " +
               $"vague, or not possible to express in SQL, you must never mention SQL or schemas to the user. " +
               $"Infer meaning where possible and return the query based on your intuition unless your are certain " +
               $"you don't have an answer. " +
               $"If inference is uncertain, ask the user to clarify by providing related terms based on the schema. " +
               $"Return SQL ONLY if you fully understand the request. Otherwise, respond naturally, as if you are" +
               $" retrieving the data yourself.";
    }





    
    // private static string GenerateSqlSchemaSystemPrompt(string schema)
    // {
    //     return $"You are an AI assistant that retrieves data from a structured database. " +
    //            $"You generate SQL queries based on user requests, following this schema: {schema}. " +
    //            $"Always return only the SQL query, formatted correctly for SQL Server, unless the request is invalid. " +
    //            $"If the request is unclear or doesn't match the schema, respond as if you couldn't find the requested data, " +
    //            $"and politely guide the user to rephrase their request in a way that aligns with the available data," +
    //            $"for example, providing the user with simplified table names inside schema." +
    //            $"Never mention SQL or that you are generating queries. Assume users prefer names over IDs unless stated otherwise. " +
    //            $"Keep responses concise and on-topic, strictly within the context of the schema.";
    // }


}