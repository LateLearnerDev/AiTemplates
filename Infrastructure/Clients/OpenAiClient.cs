using System.Net.Http.Json;
using System.Text.Json;

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

    public async Task<IEnumerable<TResponse>?> GetListAsync<TResponse>(string endpoint)
    {
        var response = await httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        using var document = JsonDocument.Parse(responseContent);

        return document.RootElement.TryGetProperty("data", out var dataElement)
            ? JsonSerializer.Deserialize<IEnumerable<TResponse>>(dataElement.GetRawText())
            : null;
    }
}