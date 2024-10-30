using Application.Common.Interfaces;
using CommunityToolkit.Diagnostics;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Gyms;

public class DeleteGymRequest(int id) : IRequest<bool>
{
    public int Id { get; set; } = id;
}

public class DeleteGymRequestHandler(IRepository<Gym> repository) : IRequestHandler<DeleteGymRequest, bool>
{
    public async Task<bool> Handle(DeleteGymRequest request, CancellationToken cancellationToken)
    {
        var gym = await repository
            .Query()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        Guard.IsNotNull(gym);

        await repository.HardDeleteAsync(gym);
        return true;
    }
}