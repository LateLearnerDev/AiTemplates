using System.Diagnostics;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Storage.Persistence.Context;

public class AiTemplatesDbContext(DbContextOptions<AiTemplatesDbContext> options) : DbContext(options)
{
    public async Task<int> SaveChangesAsync()
    {
        try
        {
            var affected = await base.SaveChangesAsync();
            return affected;
        }
        catch (DbUpdateException e)
        {
            Debug.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            throw;
        }

        return await base.SaveChangesAsync();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        // Seed Gyms
        modelBuilder.Entity<Gym>().HasData(
            new Gym { Id = 1, Name = "Downtown Gym" },
            new Gym { Id = 2, Name = "Fitness World" },
            new Gym { Id = 3, Name = "Elite Performance" }
        );
        
        // Seed Exercises
        modelBuilder.Entity<Exercise>().HasData(
            new Exercise { Id = 1, Name = "Incline Bench Press", Description = "Upper chest exercise" },
            new Exercise { Id = 2, Name = "Squat", Description = "Leg exercise" },
            new Exercise { Id = 3, Name = "Deadlift", Description = "Full-body compound lift" },
            new Exercise { Id = 4, Name = "Pull-Up", Description = "Upper back exercise" },
            new Exercise { Id = 5, Name = "Push-Up", Description = "Chest Exercise" },
            new Exercise { Id = 6, Name = "Leg Extension", Description = "Quad Exercise" },
            new Exercise { Id = 7, Name = "Skull Crusher", Description = "Triceps Exercise" },
            new Exercise { Id = 8, Name = "Close-Grip Flat Bench Press", Description = "Triceps/Chest Exercise" },
            new Exercise { Id = 9, Name = "Lat Pull Down", Description = "Back Exercise" },
            new Exercise { Id = 10, Name = "Bicep Curl", Description = "Bicep Exercise" }
        );
        
        // Seed Equipment
        modelBuilder.Entity<GymEquipment>().HasData(
            new GymEquipment { Id = 1, Name = "Incline Bench Press Machine", GymId = 1},
            new GymEquipment { Id = 2, Name = "Barbell", GymId = 1},
            new GymEquipment { Id = 3, Name = "Dumbbells", GymId = 1},
            new GymEquipment { Id = 4, Name = "Squat Rack", GymId = 1},
            new GymEquipment { Id = 5, Name = "Leg Extension Machine", GymId = 2},
            new GymEquipment { Id = 6, Name = "Dumbbells", GymId = 2},
            new GymEquipment { Id = 7, Name = "Barbell", GymId = 2},
            new GymEquipment { Id = 8, Name = "Pull-Up Bar", GymId = 3},
            new GymEquipment { Id = 9, Name = "Flat Sit-Down Chest Press Machine", GymId = 3},
            new GymEquipment { Id = 10, Name = "Barbell", GymId = 3}
        );
        
        modelBuilder.Entity<GymEquipmentExercise>().HasData(
            // Barbell at Fitness World is used for Deadlift, Squat, Bicep Curl
            new GymEquipmentExercise { Id = 1, GymEquipmentId = 7, ExerciseId = 3 },  // Barbell + Deadlift
            new GymEquipmentExercise { Id = 2, GymEquipmentId = 7, ExerciseId = 2 },  // Barbell + Squat
            new GymEquipmentExercise { Id = 3, GymEquipmentId = 7, ExerciseId = 10 },  // Barbell + Bicep Curl
            // Squat Rack at Downtown Gym for Squat
            new GymEquipmentExercise { Id = 4, GymEquipmentId = 4, ExerciseId = 2 },  // Squat Rack + Squat
            // Incline Bench Press Machine at Downtown Gym for Incline Bench Press
            new GymEquipmentExercise { Id = 5, GymEquipmentId = 1, ExerciseId = 1 },  // Incline Bench Press Machine + Incline Bench Press
            // Pull-Up Bar at Elite Performance for Pull-Up
            new GymEquipmentExercise { Id = 6, GymEquipmentId = 8, ExerciseId = 4 }   // Pull-Up Bar + Pull-Up
        );
        
        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "John", LastName = "Doe", LoginId = null },
            new User { Id = 2, FirstName = "Jane", LastName = "Smith", LoginId = null }
        );
        
        // Seed Cycles
        modelBuilder.Entity<Cycle>().HasData(
            new Cycle
            {
                Id = 1, Name = "Strength Training Cycle", StartDate = new DateTime(2024, 4, 1).ToUniversalTime(), LengthInWeeks = 4,
                EndDate = new DateTime(2024, 5, 15).ToUniversalTime(), UserId = 1
            },
            new Cycle
            {
                Id = 2, Name = "Hypertrophy Cycle", StartDate = new DateTime(2024, 5, 1).ToUniversalTime(), LengthInWeeks = 6,
                EndDate = null, UserId = 2
            }
        );
        
        // Seed Workouts (with and without cycles)
        modelBuilder.Entity<Workout>().HasData(
            new Workout { Id = 1, UserId = 1, Date = new DateTime(2024, 4, 1).ToUniversalTime(), CycleId = 1 },
            new Workout { Id = 2, UserId = 1, Date = new DateTime(2024, 4, 3).ToUniversalTime(), CycleId = 1 },
            new Workout { Id = 3, UserId = 2, Date = new DateTime(2024, 3, 1).ToUniversalTime(), CycleId = null }, // No cycle
            new Workout { Id = 4, UserId = 2, Date = new DateTime(2024, 5, 1).ToUniversalTime(), CycleId = 2 }
        );
        
        // Seed Workout Exercises
        modelBuilder.Entity<WorkoutExercise>().HasData(
            new WorkoutExercise { Id = 1, WorkoutId = 1, ExerciseId = 1, Notes = "Good form" },
            new WorkoutExercise { Id = 2, WorkoutId = 2, ExerciseId = 2, Notes = "Increased weight" },
            new WorkoutExercise { Id = 3, WorkoutId = 3, ExerciseId = 3, Notes = "Tough day" },
            new WorkoutExercise { Id = 4, WorkoutId = 4, ExerciseId = 4, Notes = "Felt strong" }
        );
        
        // Seed Workout Sets
        modelBuilder.Entity<WorkoutExerciseSet>().HasData(
            // For Workout 1 (Incline Bench Press)
            new WorkoutExerciseSet { Id = 1, WorkoutExerciseId = 1, SetNumber = 1, RepCount = 10, Weight = 100 },
            new WorkoutExerciseSet { Id = 2, WorkoutExerciseId = 1, SetNumber = 2, RepCount = 8, Weight = 105 },
            // For Workout 2 (Squat)
            new WorkoutExerciseSet { Id = 3, WorkoutExerciseId = 2, SetNumber = 1, RepCount = 8, Weight = 120 },
            new WorkoutExerciseSet { Id = 4, WorkoutExerciseId = 2, SetNumber = 2, RepCount = 6, Weight = 125 },
            // For Workout 3 (Deadlift)
            new WorkoutExerciseSet { Id = 5, WorkoutExerciseId = 3, SetNumber = 1, RepCount = 5, Weight = 140 },
            new WorkoutExerciseSet { Id = 6, WorkoutExerciseId = 3, SetNumber = 2, RepCount = 5, Weight = 145 },
            // For Workout 4 (Pull-Up)
            new WorkoutExerciseSet { Id = 7, WorkoutExerciseId = 4, SetNumber = 1, RepCount = 12, Weight = 0 },
            new WorkoutExerciseSet { Id = 8, WorkoutExerciseId = 4, SetNumber = 2, RepCount = 10, Weight = 0 }
        );
    }
}