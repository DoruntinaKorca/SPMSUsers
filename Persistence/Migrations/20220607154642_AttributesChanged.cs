using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AttributesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_AddressDetailsId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "AddressDetailsId",
                table: "AspNetUsers",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AddressDetailsId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CityId");

            migrationBuilder.AddColumn<string>(
                name: "AddressDetails",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressDetails",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "AspNetUsers",
                newName: "AddressDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AddressDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_AddressDetailsId",
                table: "AspNetUsers",
                column: "AddressDetailsId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
