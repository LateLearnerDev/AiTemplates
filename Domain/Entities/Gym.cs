namespace Domain.Entities;

public class Gym
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<GymEquipment> GymEquipments { get; set; } = new List<GymEquipment>();
}