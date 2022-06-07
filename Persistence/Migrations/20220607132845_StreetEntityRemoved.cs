using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class StreetEntityRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Streets_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AddressDetailsId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressDetailsId",
                table: "AspNetUsers",
                column: "AddressDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_AddressDetailsId",
                table: "AspNetUsers",
                column: "AddressDetailsId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_AddressDetailsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressDetailsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressDetailsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    StreetId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    StreetName = table.Column<string>(type: "TEXT", nullable: false),
                    StreetNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.StreetId);
                    table.ForeignKey(
                        name: "FK_Streets_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_CityId",
                table: "Streets",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_StreetName",
                table: "Streets",
                column: "StreetName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Streets_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Streets",
                principalColumn: "StreetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
