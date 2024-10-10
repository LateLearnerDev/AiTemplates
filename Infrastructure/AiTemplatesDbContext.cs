using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AiTemplatesDbContext(DbContextOptions<AiTemplatesDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Cycle> Cycles { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Gym> Gyms { get; set; }
    public DbSet<LoginDetails> LoginDetails { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<WorkoutExerciseSet> WorkoutExerciseSets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}