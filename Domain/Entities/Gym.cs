namespace Domain.Entities;

public class Gym : Entity
{
    public required string Name { get; set; }
    public ICollection<GymEquipment> GymEquipments { get; set; } = new List<GymEquipment>();
}