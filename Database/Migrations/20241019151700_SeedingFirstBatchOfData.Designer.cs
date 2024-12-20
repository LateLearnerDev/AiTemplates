﻿// <auto-generated />
using System;
using Infrastructure;
using Infrastructure.Storage.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AiTemplatesDbContext))]
    [Migration("20241019151700_SeedingFirstBatchOfData")]
    partial class SeedingFirstBatchOfData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Cycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LengthInWeeks")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cycles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2024, 10, 17, 15, 17, 0, 40, DateTimeKind.Utc).AddTicks(1055),
                            LengthInWeeks = 4,
                            Name = "Strength Training Cycle",
                            StartDate = new DateTime(2024, 9, 19, 15, 17, 0, 40, DateTimeKind.Utc).AddTicks(993),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            LengthInWeeks = 6,
                            Name = "Hypertrophy Cycle",
                            StartDate = new DateTime(2024, 10, 5, 15, 17, 0, 40, DateTimeKind.Utc).AddTicks(1059),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Exercises", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Upper chest exercise",
                            Name = "Incline Bench Press"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Leg exercise",
                            Name = "Squat"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Full-body compound lift",
                            Name = "Deadlift"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Upper back exercise",
                            Name = "Pull-Up"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Chest Exercise",
                            Name = "Push-Up"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Quad Exercise",
                            Name = "Leg Extension"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Triceps Exercise",
                            Name = "Skull Crusher"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Triceps/Chest Exercise",
                            Name = "Close-Grip Flat Bench Press"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Back Exercise",
                            Name = "Lat Pull Down"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Bicep Exercise",
                            Name = "Bicep Curl"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Gyms", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Downtown Gym"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fitness World"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Elite Performance"
                        });
                });

            modelBuilder.Entity("Domain.Entities.GymEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GymId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GymId");

                    b.ToTable("GymEquipments", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GymId = 1,
                            Name = "Incline Bench Press Machine"
                        },
                        new
                        {
                            Id = 2,
                            GymId = 1,
                            Name = "Barbell"
                        },
                        new
                        {
                            Id = 3,
                            GymId = 1,
                            Name = "Dumbbells"
                        },
                        new
                        {
                            Id = 4,
                            GymId = 1,
                            Name = "Squat Rack"
                        },
                        new
                        {
                            Id = 5,
                            GymId = 2,
                            Name = "Leg Extension Machine"
                        },
                        new
                        {
                            Id = 6,
                            GymId = 2,
                            Name = "Dumbbells"
                        },
                        new
                        {
                            Id = 7,
                            GymId = 2,
                            Name = "Barbell"
                        },
                        new
                        {
                            Id = 8,
                            GymId = 3,
                            Name = "Pull-Up Bar"
                        },
                        new
                        {
                            Id = 9,
                            GymId = 3,
                            Name = "Flat Sit-Down Chest Press Machine"
                        },
                        new
                        {
                            Id = 10,
                            GymId = 3,
                            Name = "Barbell"
                        });
                });

            modelBuilder.Entity("Domain.Entities.GymEquipmentExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("GymEquipmentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("GymEquipmentId");

                    b.ToTable("GymEquipmentExercises", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseId = 3,
                            GymEquipmentId = 7
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 2,
                            GymEquipmentId = 7
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 10,
                            GymEquipmentId = 7
                        },
                        new
                        {
                            Id = 4,
                            ExerciseId = 2,
                            GymEquipmentId = 4
                        },
                        new
                        {
                            Id = 5,
                            ExerciseId = 1,
                            GymEquipmentId = 1
                        },
                        new
                        {
                            Id = 6,
                            ExerciseId = 4,
                            GymEquipmentId = 8
                        });
                });

            modelBuilder.Entity("Domain.Entities.LoginDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LoginDetails", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("LoginId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LoginId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Jane",
                            LastName = "Smith"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CycleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CycleId");

                    b.HasIndex("UserId");

                    b.ToTable("Workouts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CycleId = 1,
                            Date = new DateTime(2024, 9, 29, 15, 17, 0, 40, DateTimeKind.Utc).AddTicks(1076),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CycleId = 1,
                            Date = new DateTime(2024, 10, 1, 15, 17, 0, 40, DateTimeKind.Utc).AddTicks(1079),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 10, 9, 15, 17, 0, 40, DateTimeKind.Utc).AddTicks(1081),
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            CycleId = 2,
                            Date = new DateTime(2024, 10, 12, 15, 17, 0, 40, DateTimeKind.Utc).AddTicks(1084),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.WorkoutExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int?>("GymEquipmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("GymEquipmentId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutExercises", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseId = 1,
                            Notes = "Good form",
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 2,
                            Notes = "Increased weight",
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 3,
                            Notes = "Tough day",
                            WorkoutId = 3
                        },
                        new
                        {
                            Id = 4,
                            ExerciseId = 4,
                            Notes = "Felt strong",
                            WorkoutId = 4
                        });
                });

            modelBuilder.Entity("Domain.Entities.WorkoutExerciseSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RepCount")
                        .HasColumnType("integer");

                    b.Property<int>("SetNumber")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.Property<int>("WorkoutExerciseId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutExerciseId");

                    b.ToTable("WorkoutExerciseSets", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RepCount = 10,
                            SetNumber = 1,
                            Weight = 100,
                            WorkoutExerciseId = 1
                        },
                        new
                        {
                            Id = 2,
                            RepCount = 8,
                            SetNumber = 2,
                            Weight = 105,
                            WorkoutExerciseId = 1
                        },
                        new
                        {
                            Id = 3,
                            RepCount = 8,
                            SetNumber = 1,
                            Weight = 120,
                            WorkoutExerciseId = 2
                        },
                        new
                        {
                            Id = 4,
                            RepCount = 6,
                            SetNumber = 2,
                            Weight = 125,
                            WorkoutExerciseId = 2
                        },
                        new
                        {
                            Id = 5,
                            RepCount = 5,
                            SetNumber = 1,
                            Weight = 140,
                            WorkoutExerciseId = 3
                        },
                        new
                        {
                            Id = 6,
                            RepCount = 5,
                            SetNumber = 2,
                            Weight = 145,
                            WorkoutExerciseId = 3
                        },
                        new
                        {
                            Id = 7,
                            RepCount = 12,
                            SetNumber = 1,
                            Weight = 0,
                            WorkoutExerciseId = 4
                        },
                        new
                        {
                            Id = 8,
                            RepCount = 10,
                            SetNumber = 2,
                            Weight = 0,
                            WorkoutExerciseId = 4
                        });
                });

            modelBuilder.Entity("Domain.Entities.Cycle", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Cycles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.GymEquipment", b =>
                {
                    b.HasOne("Domain.Entities.Gym", "Gym")
                        .WithMany("GymEquipments")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("Domain.Entities.GymEquipmentExercise", b =>
                {
                    b.HasOne("Domain.Entities.Exercise", "Exercise")
                        .WithMany("GymEquipmentExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.GymEquipment", "GymEquipment")
                        .WithMany("GymEquipmentExercises")
                        .HasForeignKey("GymEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("GymEquipment");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.LoginDetails", "LoginDetails")
                        .WithMany()
                        .HasForeignKey("LoginId");

                    b.Navigation("LoginDetails");
                });

            modelBuilder.Entity("Domain.Entities.Workout", b =>
                {
                    b.HasOne("Domain.Entities.Cycle", "Cycle")
                        .WithMany("Workouts")
                        .HasForeignKey("CycleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cycle");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.WorkoutExercise", b =>
                {
                    b.HasOne("Domain.Entities.Exercise", "Exercise")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.GymEquipment", "GymEquipment")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("GymEquipmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.Entities.Workout", "Workout")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("GymEquipment");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Domain.Entities.WorkoutExerciseSet", b =>
                {
                    b.HasOne("Domain.Entities.WorkoutExercise", "WorkoutExercise")
                        .WithMany("WorkoutExerciseSets")
                        .HasForeignKey("WorkoutExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkoutExercise");
                });

            modelBuilder.Entity("Domain.Entities.Cycle", b =>
                {
                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.Navigation("GymEquipmentExercises");

                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("Domain.Entities.Gym", b =>
                {
                    b.Navigation("GymEquipments");
                });

            modelBuilder.Entity("Domain.Entities.GymEquipment", b =>
                {
                    b.Navigation("GymEquipmentExercises");

                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Cycles");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("Domain.Entities.Workout", b =>
                {
                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("Domain.Entities.WorkoutExercise", b =>
                {
                    b.Navigation("WorkoutExerciseSets");
                });
#pragma warning restore 612, 618
        }
    }
}
