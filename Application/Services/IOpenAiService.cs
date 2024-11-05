namespace Application.Services;

public interface IOpenAiService
{
    Task<string> GenerateTextAsync(string prompt);
}