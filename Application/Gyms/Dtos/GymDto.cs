using Domain.Entities;

namespace Application.Gyms.Dtos;

public class GymDto
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public static GymDto From(Gym gym)
    {
        return new()
        {
            Id = gym.Id,
            Name = gym.Name
        };
    }
}