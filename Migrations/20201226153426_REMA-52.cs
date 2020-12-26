using Microsoft.EntityFrameworkCore.Migrations;

namespace REMA.Migrations
{
    public partial class REMA52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Apartments",
                newName: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "Apartments",
                newName: "Id");
        }
    }
}
