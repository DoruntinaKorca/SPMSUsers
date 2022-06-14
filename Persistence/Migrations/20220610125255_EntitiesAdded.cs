using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LectureGroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "StudentsLectureGroups",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LectureGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsLectureGroups", x => new { x.StudentId, x.LectureGroupId });
                    table.ForeignKey(
                        name: "Student_LectureGroup",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsSpecializations",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SpecializationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSpecializations", x => new { x.StudentId, x.SpecializationId });
                    table.ForeignKey(
                        name: "Student_Specializations",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsLectureGroups");

            migrationBuilder.DropTable(
                name: "StudentsSpecializations");

            migrationBuilder.AddColumn<int>(
                name: "LectureGroupId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
