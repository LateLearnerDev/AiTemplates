using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGymEquipmentExerciseTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.AddColumn<int>(
                name: "GymEquipmentId",
                table: "WorkoutExercises",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GymEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GymId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymEquipments_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymEquipmentExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GymEquipmentId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymEquipmentExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymEquipmentExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymEquipmentExercises_GymEquipments_GymEquipmentId",
                        column: x => x.GymEquipmentId,
                        principalTable: "GymEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Upper chest exercise", "Incline Bench Press" },
                    { 2, "Leg exercise", "Squat" },
                    { 3, "Full-body compound lift", "Deadlift" },
                    { 4, "Upper back exercise", "Pull-Up" },
                    { 5, "Chest Exercise", "Push-Up" },
                    { 6, "Quad Exercise", "Leg Extension" },
                    { 7, "Triceps Exercise", "Skull Crusher" },
                    { 8, "Triceps/Chest Exercise", "Close-Grip Flat Bench Press" },
                    { 9, "Back Exercise", "Lat Pull Down" },
                    { 10, "Bicep Exercise", "Bicep Curl" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Downtown Gym" },
                    { 2, "Fitness World" },
                    { 3, "Elite Performance" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastNameName", "LoginId" },
                values: new object[,]
                {
                    { 1, "John", "Doe", null },
                    { 2, "Jane", "Smith", null }
                });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "EndDate", "LengthInWeeks", "Name", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 12, 20, 34, 26, 900, DateTimeKind.Utc).AddTicks(3706), 4, "Strength Training Cycle", new DateTime(2024, 9, 14, 20, 34, 26, 900, DateTimeKind.Utc).AddTicks(3653), 1 },
                    { 2, null, 6, "Hypertrophy Cycle", new DateTime(2024, 9, 30, 20, 34, 26, 900, DateTimeKind.Utc).AddTicks(3710), 2 }
                });

            migrationBuilder.InsertData(
                table: "GymEquipments",
                columns: new[] { "Id", "GymId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Incline Bench Press Machine" },
                    { 2, 1, "Barbell" },
                    { 3, 1, "Dumbbells" },
                    { 4, 1, "Squat Rack" },
                    { 5, 2, "Leg Extension Machine" },
                    { 6, 2, "Dumbbells" },
                    { 7, 2, "Barbell" },
                    { 8, 3, "Pull-Up Bar" },
                    { 9, 3, "Flat Sit-Down Chest Press Machine" },
                    { 10, 3, "Barbell" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CycleId", "Date", "UserId" },
                values: new object[] { 3, null, new DateTime(2024, 10, 4, 20, 34, 26, 900, DateTimeKind.Utc).AddTicks(3728), 2 });

            migrationBuilder.InsertData(
                table: "GymEquipmentExercises",
                columns: new[] { "Id", "ExerciseId", "GymEquipmentId" },
                values: new object[,]
                {
                    { 1, 3, 7 },
                    { 2, 2, 7 },
                    { 3, 10, 7 },
                    { 4, 2, 4 },
                    { 5, 1, 1 },
                    { 6, 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "WorkoutExercises",
                columns: new[] { "Id", "ExerciseId", "GymEquipmentId", "Notes", "WorkoutId" },
                values: new object[] { 3, 3, null, "Tough day", 3 });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CycleId", "Date", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 24, 20, 34, 26, 900, DateTimeKind.Utc).AddTicks(3723), 1 },
                    { 2, 1, new DateTime(2024, 9, 26, 20, 34, 26, 900, DateTimeKind.Utc).AddTicks(3726), 1 },
                    { 4, 2, new DateTime(2024, 10, 7, 20, 34, 26, 900, DateTimeKind.Utc).AddTicks(3731), 2 }
                });

            migrationBuilder.InsertData(
                table: "WorkoutExerciseSets",
                columns: new[] { "Id", "RepCount", "SetNumber", "Weight", "WorkoutExerciseId" },
                values: new object[,]
                {
                    { 5, 5, 1, 140, 3 },
                    { 6, 5, 2, 145, 3 }
                });

            migrationBuilder.InsertData(
                table: "WorkoutExercises",
                columns: new[] { "Id", "ExerciseId", "GymEquipmentId", "Notes", "WorkoutId" },
                values: new object[,]
                {
                    { 1, 1, null, "Good form", 1 },
                    { 2, 2, null, "Increased weight", 2 },
                    { 4, 4, null, "Felt strong", 4 }
                });

            migrationBuilder.InsertData(
                table: "WorkoutExerciseSets",
                columns: new[] { "Id", "RepCount", "SetNumber", "Weight", "WorkoutExerciseId" },
                values: new object[,]
                {
                    { 1, 10, 1, 100, 1 },
                    { 2, 8, 2, 105, 1 },
                    { 3, 8, 1, 120, 2 },
                    { 4, 6, 2, 125, 2 },
                    { 7, 12, 1, 0, 4 },
                    { 8, 10, 2, 0, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_GymEquipmentId",
                table: "WorkoutExercises",
                column: "GymEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GymEquipmentExercises_ExerciseId",
                table: "GymEquipmentExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_GymEquipmentExercises_GymEquipmentId",
                table: "GymEquipmentExercises",
                column: "GymEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GymEquipments_GymId",
                table: "GymEquipments",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_GymEquipments_GymEquipmentId",
                table: "WorkoutExercises",
                column: "GymEquipmentId",
                principalTable: "GymEquipments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_GymEquipments_GymEquipmentId",
                table: "WorkoutExercises");

            migrationBuilder.DropTable(
                name: "GymEquipmentExercises");

            migrationBuilder.DropTable(
                name: "GymEquipments");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercises_GymEquipmentId",
                table: "WorkoutExercises");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutExerciseSets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutExerciseSets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutExerciseSets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutExerciseSets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkoutExerciseSets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkoutExerciseSets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WorkoutExerciseSets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WorkoutExerciseSets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cycles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cycles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "GymEquipmentId",
                table: "WorkoutExercises");

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    GymId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ExerciseId",
                table: "Equipments",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_GymId",
                table: "Equipments",
                column: "GymId");
        }
    }
}
