using System.Net.Http.Json;
using System.Text.Json;

namespace Infrastructure.Clients;

public class OpenAiClient(HttpClient httpClient) : IOpenAiClient
{
    public async Task<string> GenerateTextAsync(string prompt)
    {
        var systemMessage = new
        {
            role = "system", content = "You are a helpful assistant."
        };
        var userMessage = new
        {
            role = "user", content = prompt
        };
        
        var requestBody = new
        {
            model = "gpt-4o",  // You can specify other models, e.g., gpt-3.5-turbo or gpt-4
            messages = (object[])[systemMessage, userMessage],
            max_tokens = 100,            // Adjust this according to your needs
            temperature = 0.7            // Controls creativity; higher values produce more varied outputs
        };

        var response = await httpClient.PostAsJsonAsync("chat/completions", requestBody);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonDocument.Parse(responseContent)
            .RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return result ?? string.Empty;
    }
}