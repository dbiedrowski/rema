using Microsoft.EntityFrameworkCore.Migrations;

namespace REMA.Migrations
{
    public partial class REMA92MakeApartmentsHaveNumberOfRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRooms",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "Apartments");
        }
    }
}
