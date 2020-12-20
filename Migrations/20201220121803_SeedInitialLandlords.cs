using Microsoft.EntityFrameworkCore.Migrations;

namespace REMA.Migrations
{
    public partial class SeedInitialLandlords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "FirstName", "LastName" },
                values: new object[] { 1, "Damian", "Biedrowski" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "FirstName", "LastName" },
                values: new object[] { 2, "Konrad", "Biedrowski" });

            migrationBuilder.InsertData(
                table: "Landlords",
                columns: new[] { "Id", "ProfileId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Landlords",
                columns: new[] { "Id", "ProfileId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: 2);
        }
    }
}
