﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AiTemplatesDbContext))]
    [Migration("20241017133008_MappingModels")]
    partial class MappingModels
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

                    b.Property<string>("LastNameName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("LoginId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LoginId");

                    b.ToTable("Users", (string)null);
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
