namespace Application.Common.Services;

public interface IOpenAiService
{
    Task<string> GenerateTextAsync(string prompt);
}