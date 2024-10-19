using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MappingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_GymEquipments_GymEquipmentId",
                table: "WorkoutExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Cycles_CycleId",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_GymEquipments_GymEquipmentId",
                table: "WorkoutExercises",
                column: "GymEquipmentId",
                principalTable: "GymEquipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Cycles_CycleId",
                table: "Workouts",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_GymEquipments_GymEquipmentId",
                table: "WorkoutExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Cycles_CycleId",
                table: "Workouts");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_GymEquipments_GymEquipmentId",
                table: "WorkoutExercises",
                column: "GymEquipmentId",
                principalTable: "GymEquipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Cycles_CycleId",
                table: "Workouts",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id");
        }
    }
}
