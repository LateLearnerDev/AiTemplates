using Application.OpenAi.Completions.Dtos;

namespace Application.OpenAi.Completions.Services;

public interface ICompletionService
{
    Task<CompletionDto?> CreateCompletionAsync(string systemPrompt, string userPrompt);
}