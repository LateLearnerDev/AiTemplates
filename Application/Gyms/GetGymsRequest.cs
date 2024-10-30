using Application.Common.Interfaces;
using Application.Gyms.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Gyms;

public class GetGymsRequest : IRequest<IEnumerable<GymDto>>
{
    
}

public class GetGymRequestsHandler(IRepository<Gym> repository) : IRequestHandler<GetGymsRequest, IEnumerable<GymDto>>
{
    public async Task<IEnumerable<GymDto>> Handle(GetGymsRequest request, CancellationToken cancellationToken)
    {
        var gyms = await repository.Query()
            .ToListAsync(cancellationToken: cancellationToken);
        return gyms.Select(GymDto.From);
    }
}