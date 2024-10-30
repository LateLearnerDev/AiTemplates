namespace Domain.Entities;

public class Gym : Entity
{
    public required string Name { get; set; }
    public ICollection<GymEquipment> GymEquipments { get; set; } = new List<GymEquipment>();

    public static Gym Create(string name)
    {
        return new()
        {
            Name = name
        };
    }

    public void Update(string name)
    {
        Name = name;
    }
}