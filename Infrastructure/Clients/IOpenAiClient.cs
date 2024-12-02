using Infrastructure.Clients.Models;

namespace Infrastructure.Clients;

public interface IOpenAiClient
{
    Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest body) where TRequest : class;
    Task<TResponse?> GetAsync<TResponse>(string endpoint);
    Task<IEnumerable<TResponse>?> GetListAsync<TResponse>(string endpoint);
}