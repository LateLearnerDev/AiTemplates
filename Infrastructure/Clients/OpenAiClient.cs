using System.Net.Http.Json;

namespace Infrastructure.Clients;

public class OpenAiClient(HttpClient httpClient) : IOpenAiClient
{
    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest body) where TRequest : class
    {
        var response = await httpClient.PostAsJsonAsync(endpoint, body);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<TResponse?> GetAsync<TResponse>(string endpoint)
    {
        var response = await httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
}