
using System.ClientModel;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using MediatR;
using OpenAI.Chat;

namespace Application.AzureOpenAi.Completions;

public class CreateAzureCompletionRequest : IRequest<ChatMessageContent>
{
    public required string SystemPrompt { get; set; }
    public required string UserPrompt { get; set; }
}

public class CreateAzureCompletionRequestHandler(IConfiguration configuration) : IRequestHandler<CreateAzureCompletionRequest, ChatMessageContent>
{
    public async Task<ChatMessageContent> Handle(CreateAzureCompletionRequest request, CancellationToken cancellationToken)
    {
        var endpoint = configuration["AzureOpenAiBaseEndpoint"];
        var key = configuration["AzureOpenAiKey"];
        var azureOpenAiClient = new AzureOpenAIClient(new Uri(endpoint),
            new ApiKeyCredential(key));
        var completionClient = azureOpenAiClient.GetChatClient("gpt-4o-mini");
        
        var chatMessages = new List<ChatMessage>
        {
            ChatMessage.CreateSystemMessage(request.SystemPrompt),
            ChatMessage.CreateUserMessage(request.UserPrompt),
        };
        
        var response = await completionClient.CompleteChatAsync(chatMessages, new ChatCompletionOptions
        {
           Temperature = 0.5f,
           MaxOutputTokenCount = 800
        }, cancellationToken: cancellationToken);


        return response.Value.Content;
    }
}
