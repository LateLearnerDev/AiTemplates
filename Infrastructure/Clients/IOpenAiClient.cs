namespace Infrastructure.Clients;

public interface IOpenAiClient
{
    Task<string> GenerateTextAsync(string prompt);
}