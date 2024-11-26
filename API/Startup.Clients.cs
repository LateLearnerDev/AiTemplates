using System.Net.Http.Headers;
using Infrastructure.Clients;

namespace API;

public static class StartupClients
{
    public static void AddOpenAiClient(this IServiceCollection services, string openAiApiKey)
    {
        services.AddHttpClient<IOpenAiClient, OpenAiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.openai.com/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", openAiApiKey);
            client.DefaultRequestHeaders.Add("OpenAI-Beta", "assistants=v2");
        });
    }
}