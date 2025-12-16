using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoTaskApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigraion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taskCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 12, 16, 11, 27, 14, 984, DateTimeKind.Local).AddTicks(2870))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "todoTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 12, 16, 11, 27, 14, 985, DateTimeKind.Local).AddTicks(79)),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TaskCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todoTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_todoTasks_taskCategories_TaskCategoryId",
                        column: x => x.TaskCategoryId,
                        principalTable: "taskCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_todoTasks_TaskCategoryId",
                table: "todoTasks",
                column: "TaskCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todoTasks");

            migrationBuilder.DropTable(
                name: "taskCategories");
        }
    }
}
