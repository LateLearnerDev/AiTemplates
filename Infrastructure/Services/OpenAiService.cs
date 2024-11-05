using Application.Services;
using Infrastructure.Clients;

namespace Infrastructure.Services;

public class OpenAiService(IOpenAiClient openAiClient) : IOpenAiService
{
    public async Task<string> GenerateTextAsync(string prompt)
    {
        return await openAiClient.GenerateTextAsync(prompt);
    }
}