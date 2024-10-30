using Application.Common.Interfaces;
using Application.Gyms.Dtos;
using CommunityToolkit.Diagnostics;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Gyms;

public class UpdateGymRequest(int id, string name) : IRequest<GymDto>
{
    public int Id { get; set; } = id;
    public required string Name { get; set; } = name;
}

public class UpdateGymRequestHandler(IRepository<Gym> repository) : IRequestHandler<UpdateGymRequest, GymDto>
{
    public async Task<GymDto> Handle(UpdateGymRequest request, CancellationToken cancellationToken)
    {
        var gym = await repository
            .Query()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        Guard.IsNotNull(gym);

        gym.Update(request.Name); 

        var updated = await repository.UpdateAsync(gym);
        return GymDto.From(updated);
    }
}