using Application.Gyms.Dtos;
using MediatR;

namespace Application.Gyms;

public class GetGymsRequest : IRequest<IEnumerable<GymDto>>
{
    
}

public class GetGymsRequestHandler : IRequestHandler<GetGymsRequest, IEnumerable<GymDto>>
{
    public Task<IEnumerable<GymDto>> Handle(GetGymsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}