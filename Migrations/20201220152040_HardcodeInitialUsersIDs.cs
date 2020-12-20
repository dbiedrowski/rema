using Microsoft.EntityFrameworkCore.Migrations;

namespace REMA.Migrations
{
    public partial class HardcodeInitialUsersIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "753fe54e-e312-4abd-838e-5e713fd32550");

            migrationBuilder.UpdateData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "31704aae-e67a-44b8-b5c1-65551502ea2c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);
        }
    }
}
