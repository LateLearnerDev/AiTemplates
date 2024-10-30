using Application.Common.Interfaces;
using Application.Gyms.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.Gyms;

public class CreateGymRequest : IRequest<GymDto>
{
    public required string Name { get; set; }
}

public class CreateGymRequestHandler(IRepository<Gym> repository) : IRequestHandler<CreateGymRequest, GymDto>
{
    public async Task<GymDto> Handle(CreateGymRequest request, CancellationToken cancellationToken)
    {
        var gym = await repository.AddAsync(Gym.Create(request.Name));
        return GymDto.From(gym);
    }
}