using Application.Common.Interfaces;
using Application.Gyms.Dtos;
using CommunityToolkit.Diagnostics;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Gyms;

public class GetGymByIdRequest(int id) : IRequest<GymDto>
{
    public int Id { get; set; } = id;
}

public class GetGymByIdRequestHandler(IRepository<Gym> repository) : IRequestHandler<GetGymByIdRequest, GymDto>
{
    public async Task<GymDto> Handle(GetGymByIdRequest request, CancellationToken cancellationToken)
    {
        var gym = await repository
            .Query()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        Guard.IsNotNull(gym);

        return GymDto.From(gym);
    }
}