using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ConstraintNamesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicStaffs_AcademicLevels_AcademicLevelId",
                table: "AcademicStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicStaffs_AspNetUsers_AcademicStaffId",
                table: "AcademicStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_AdministrativeStaffs_AspNetUsers_AdministrativeStaffId",
                table: "AdministrativeStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_CityCategories_CategoryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_StudentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Generations_GenerationId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFaculties_AspNetUsers_UserID",
                table: "UsersFaculties");

            migrationBuilder.AddForeignKey(
                name: "staffLevel_Academic",
                table: "AcademicStaffs",
                column: "AcademicLevelId",
                principalTable: "AcademicLevels",
                principalColumn: "AcademicLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "userAcademicStaff",
                table: "AcademicStaffs",
                column: "AcademicStaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "userAdministrativeStaff",
                table: "AdministrativeStaffs",
                column: "AdministrativeStaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "City_users",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "CityCategory_Cities",
                table: "Cities",
                column: "CategoryId",
                principalTable: "CityCategories",
                principalColumn: "CityCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Country_Cities",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Student_Generation",
                table: "Students",
                column: "GenerationId",
                principalTable: "Generations",
                principalColumn: "GenerationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "UserStudentISA",
                table: "Students",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "User_UsersFaculites",
                table: "UsersFaculties",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "staffLevel_Academic",
                table: "AcademicStaffs");

            migrationBuilder.DropForeignKey(
                name: "userAcademicStaff",
                table: "AcademicStaffs");

            migrationBuilder.DropForeignKey(
                name: "userAdministrativeStaff",
                table: "AdministrativeStaffs");

            migrationBuilder.DropForeignKey(
                name: "City_users",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "CityCategory_Cities",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "Country_Cities",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "Student_Generation",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "UserStudentISA",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "User_UsersFaculites",
                table: "UsersFaculties");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicStaffs_AcademicLevels_AcademicLevelId",
                table: "AcademicStaffs",
                column: "AcademicLevelId",
                principalTable: "AcademicLevels",
                principalColumn: "AcademicLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicStaffs_AspNetUsers_AcademicStaffId",
                table: "AcademicStaffs",
                column: "AcademicStaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdministrativeStaffs_AspNetUsers_AdministrativeStaffId",
                table: "AdministrativeStaffs",
                column: "AdministrativeStaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_CityCategories_CategoryId",
                table: "Cities",
                column: "CategoryId",
                principalTable: "CityCategories",
                principalColumn: "CityCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_StudentId",
                table: "Students",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Generations_GenerationId",
                table: "Students",
                column: "GenerationId",
                principalTable: "Generations",
                principalColumn: "GenerationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFaculties_AspNetUsers_UserID",
                table: "UsersFaculties",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
