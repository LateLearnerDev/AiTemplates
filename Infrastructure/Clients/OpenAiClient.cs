using System.Net.Http.Json;
using Infrastructure.Clients.Models;
using Newtonsoft.Json;

namespace Infrastructure.Clients;

public class OpenAiClient(HttpClient httpClient) : IOpenAiClient
{
    public async Task<Assistant?> CreateAssistantAsync(string name, string description, string instructions)
    {
        var request = new
        {
            name,
            description,
            instructions, 
            model = "gpt-4o"
        };
        
        var response = await httpClient.PostAsJsonAsync("assistants", request);
        response.EnsureSuccessStatusCode();
        
        var assistant = await response.Content.ReadFromJsonAsync<Assistant>();

        return assistant;
    }
    
    public async Task<Completion?> CreateCompletionAsync(string systemPrompt,
        string userPrompt)
    {
        
        var systemMessage = new
        {
            role = "system", content = systemPrompt
        };
        var userMessage = new
        {
            role = "user", content = userPrompt
        };
        
        var requestBody = new
        {
            model = "gpt-4o", 
            messages = (object[])[systemMessage, userMessage],
            max_tokens = 100,            
            temperature = 0.7,            
            store = true
        };

        var response = await httpClient.PostAsJsonAsync("chat/completions", requestBody);
        response.EnsureSuccessStatusCode();

        var completion = await response.Content.ReadFromJsonAsync<Completion>();

        return completion;
    }
}