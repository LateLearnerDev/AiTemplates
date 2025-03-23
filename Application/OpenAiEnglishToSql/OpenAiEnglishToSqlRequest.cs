using Application.Common.Extensions;
using Application.OpenAi.Assistants.Services;
using Application.OpenAi.Messages.Services;
using Application.OpenAi.Runs.Services;
using Application.OpenAi.Threads.Pros;
using Application.OpenAi.Threads.Services;
using Application.QueryRunner;
using Application.SchemaSummariser.Services;
using MediatR;

namespace Application.OpenAiEnglishToSql;

public class OpenAiEnglishToSqlRequest : IRequest<List<string>>
{
    public required string UserMessage { get; set; }
}

public class OpenAiEnglishToSqlRequestHandler(IThreadService threadService, IMessageService messageService,
    IRunService runService, IAssistantService assistantService, ISchemaSummariserService schemaSummariserService,
    IQueryRunnerService queryRunnerService) : IRequestHandler<OpenAiEnglishToSqlRequest, List<string>>
{
    public async Task<List<string>> Handle(OpenAiEnglishToSqlRequest request, CancellationToken cancellationToken)
    {
        var schema = schemaSummariserService.GetEfSummarizedSchema();
        // Todo: Change these to use the already made mediatr requests instead
        var assistant = await assistantService.CreateAssistantAsync("English to SQL Assistant", "Translates English to SQL",
            $"Assistant that converts english to sql upon user request with the following schema: {schema}. Only ever return the sql unless you don't understand the request. Please also add double quotes to all table and column names");
        var thread = await threadService.CreateThreadAsync([
            new ThreadMessagePro
            {
                Role = "user",
                Content = request.UserMessage
            }
        ]);
        
        await runService.CreateRunAsync(thread.Id, assistant.Id);
        var messages = await messageService.GetMessagesAsync(thread.Id);
        var text = messages.SelectMany(x => x.Content.Select(content => content.Text)).ToList();
        
        var cleanedText = text
            .Select(x => x.Value.RemoveMarkdownNewLinesAndSpaces())
            .ToList();

        var result = await queryRunnerService.ExecuteQueryAsync(cleanedText.First());

        return cleanedText;
    }
}