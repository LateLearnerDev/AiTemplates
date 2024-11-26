using Application.Completions.Dtos;

namespace Application.Completions.Services;

public interface ICompletionService
{
    Task<CompletionDto?> CreateCompletionAsync(string systemPrompt, string userPrompt);
}