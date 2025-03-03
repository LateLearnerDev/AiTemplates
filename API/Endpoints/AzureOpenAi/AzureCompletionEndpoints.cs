// using Application.AzureOpenAi.Completions;
// using Infrastructure.Extensions.Endpoints;
// using OpenAI.Chat;
//
// namespace API.Endpoints.AzureOpenAi;
//
// public class AzureCompletionEndpoints : IEndPointMapper
// {
//     public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
//     {
//         endpointRouteBuilder.BuildPath("AzureCompletions")
//             .MediatePost<CreateAzureCompletionRequest, ChatCompletion>("/");
//     }
// }