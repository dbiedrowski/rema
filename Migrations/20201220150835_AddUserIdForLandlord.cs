using Microsoft.EntityFrameworkCore.Migrations;

namespace REMA.Migrations
{
    public partial class AddUserIdForLandlord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Landlords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Landlords");
        }
    }
}
