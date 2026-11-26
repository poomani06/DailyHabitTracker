using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyHabitTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddHabitRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HabitRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitId = table.Column<int>(type: "int", nullable: false),
                    CompletedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HabitRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitRecords_HabitRecords_HabitRecordId",
                        column: x => x.HabitRecordId,
                        principalTable: "HabitRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HabitRecords_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitRecords_HabitId_CompletedDate",
                table: "HabitRecords",
                columns: new[] { "HabitId", "CompletedDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HabitRecords_HabitRecordId",
                table: "HabitRecords",
                column: "HabitRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitRecords");
        }
    }
}
