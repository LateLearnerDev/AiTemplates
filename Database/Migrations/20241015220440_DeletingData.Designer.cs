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
    [Migration("20241015220440_DeletingData")]
    partial class DeletingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Database.Persistence.Tables.Cycle", b =>
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

                    b.ToTable("Cycles");
                });

            modelBuilder.Entity("Database.Persistence.Tables.Exercise", b =>
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

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Database.Persistence.Tables.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Gyms");
                });

            modelBuilder.Entity("Database.Persistence.Tables.GymEquipment", b =>
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

                    b.ToTable("GymEquipments");
                });

            modelBuilder.Entity("Database.Persistence.Tables.GymEquipmentExercise", b =>
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

                    b.ToTable("GymEquipmentExercises");
                });

            modelBuilder.Entity("Database.Persistence.Tables.LoginDetails", b =>
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

                    b.ToTable("LoginDetails");
                });

            modelBuilder.Entity("Database.Persistence.Tables.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Database.Persistence.Tables.User", b =>
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

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Database.Persistence.Tables.Workout", b =>
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

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("Database.Persistence.Tables.WorkoutExercise", b =>
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

                    b.ToTable("WorkoutExercises");
                });

            modelBuilder.Entity("Database.Persistence.Tables.WorkoutExerciseSet", b =>
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

                    b.ToTable("WorkoutExerciseSets");
                });

            modelBuilder.Entity("Database.Persistence.Tables.Cycle", b =>
                {
                    b.HasOne("Database.Persistence.Tables.User", "User")
                        .WithMany("Cycles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Database.Persistence.Tables.GymEquipment", b =>
                {
                    b.HasOne("Database.Persistence.Tables.Gym", "Gym")
                        .WithMany()
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("Database.Persistence.Tables.GymEquipmentExercise", b =>
                {
                    b.HasOne("Database.Persistence.Tables.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Persistence.Tables.GymEquipment", "GymEquipment")
                        .WithMany()
                        .HasForeignKey("GymEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("GymEquipment");
                });

            modelBuilder.Entity("Database.Persistence.Tables.User", b =>
                {
                    b.HasOne("Database.Persistence.Tables.LoginDetails", "LoginDetails")
                        .WithMany()
                        .HasForeignKey("LoginId");

                    b.Navigation("LoginDetails");
                });

            modelBuilder.Entity("Database.Persistence.Tables.Workout", b =>
                {
                    b.HasOne("Database.Persistence.Tables.Cycle", "Cycle")
                        .WithMany()
                        .HasForeignKey("CycleId");

                    b.HasOne("Database.Persistence.Tables.User", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cycle");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Database.Persistence.Tables.WorkoutExercise", b =>
                {
                    b.HasOne("Database.Persistence.Tables.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Persistence.Tables.GymEquipment", "GymEquipment")
                        .WithMany()
                        .HasForeignKey("GymEquipmentId");

                    b.HasOne("Database.Persistence.Tables.Workout", "Workout")
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("GymEquipment");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Database.Persistence.Tables.WorkoutExerciseSet", b =>
                {
                    b.HasOne("Database.Persistence.Tables.WorkoutExercise", "WorkoutExercise")
                        .WithMany()
                        .HasForeignKey("WorkoutExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkoutExercise");
                });

            modelBuilder.Entity("Database.Persistence.Tables.User", b =>
                {
                    b.Navigation("Cycles");

                    b.Navigation("Workouts");
                });
#pragma warning restore 612, 618
        }
    }
}
