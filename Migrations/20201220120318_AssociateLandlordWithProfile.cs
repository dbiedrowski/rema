using Microsoft.EntityFrameworkCore.Migrations;

namespace REMA.Migrations
{
    public partial class AssociateLandlordWithProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landlords_Profiles_ProfileId",
                table: "Landlords");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profiles",
                newName: "ProfileId");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Landlords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Landlords_Profiles_ProfileId",
                table: "Landlords",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landlords_Profiles_ProfileId",
                table: "Landlords");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Profiles",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Landlords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Landlords_Profiles_ProfileId",
                table: "Landlords",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
