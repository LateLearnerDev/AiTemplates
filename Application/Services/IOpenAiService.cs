namespace Application.Services;

public interface IOpenAiService
{
    Task<string> GenerateTextAsync(string prompt);
    Task<string> GenerateCustomTextAsync(string userPrompt, string systemPrompt);
}