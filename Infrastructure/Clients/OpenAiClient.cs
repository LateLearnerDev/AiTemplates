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
        
        var responseContent = await response.Content.ReadAsStringAsync();
        var assistant = JsonConvert.DeserializeObject<Assistant>(responseContent);

        return assistant;
    }
    
    public async Task<Completion?> CreateCompletionAsync(string systemPrompt,
        string userPrompt)
    {
        // var request = new CompletionRequest
        // {
        //     Messages =
        //     [
        //         new RequestMessage
        //         {
        //             Role = "system", Content = systemPrompt
        //         },
        //
        //         new RequestMessage()
        //         {
        //             Role = "user", Content = userPrompt
        //         }
        //     ],
        //     MaxTokens = 100,
        //     Temperature = 0.7m,
        //     Store = true
        // };
        
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

        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Completion>(responseContent);

        return result;
    }
}