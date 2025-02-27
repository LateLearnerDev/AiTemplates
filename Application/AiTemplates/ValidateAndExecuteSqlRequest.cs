using System.Dynamic;
using Application.Common.Enums;
using CommunityToolkit.Diagnostics;
using MediatR;

namespace Application.AiTemplates;

public class ValidateAndExecuteSqlRequest : IRequest<List<ExpandoObject>>
{
    public required string UserQuery { get; set; }
    public required AiServiceSelection AiServiceSelection { get; set; }
    public required SchemaSelection SchemaSelection { get; set; }
}

public class ValidateAndExecuteSqlRequestHandler(ISender sender) : IRequestHandler<ValidateAndExecuteSqlRequest, List<ExpandoObject>>
{
    public async Task<List<ExpandoObject>> Handle(ValidateAndExecuteSqlRequest request, CancellationToken cancellationToken)
    {
        Guard.IsNotEmpty(request.UserQuery);
        var aiResponse = await sender.Send(new SubmitEnglishToSqlRequest
        {
            UserQuery = request.UserQuery,
            AiServiceSelection = request.AiServiceSelection,
            SchemaSelection = request.SchemaSelection
        }, cancellationToken);
        if(!aiResponse.Success)
            throw new Exception("Validation failed");

        var result = await sender.Send(new ExecuteSqlRequest
        {
            SqlQuery = aiResponse.Response
        }, cancellationToken);
        
        return result;
    }
}