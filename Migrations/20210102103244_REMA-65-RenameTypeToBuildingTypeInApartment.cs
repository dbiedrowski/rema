using Microsoft.EntityFrameworkCore.Migrations;

namespace REMA.Migrations
{
    public partial class REMA65RenameTypeToBuildingTypeInApartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Apartments",
                newName: "BuildingType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuildingType",
                table: "Apartments",
                newName: "Type");
        }
    }
}
