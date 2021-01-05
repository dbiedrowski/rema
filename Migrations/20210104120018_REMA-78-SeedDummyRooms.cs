using Microsoft.EntityFrameworkCore.Migrations;

namespace REMA.Migrations
{
    public partial class REMA78SeedDummyRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "ApartmentId", "Area", "IsFurnished", "Price", "RoomType" },
                values: new object[] { 1, 2, 7.6699999999999999, true, 700m, 0 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "ApartmentId", "Area", "IsFurnished", "Price", "RoomType" },
                values: new object[] { 2, 2, 7.71, true, 700m, 0 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "ApartmentId", "Area", "IsFurnished", "Price", "RoomType" },
                values: new object[] { 3, 2, 15.119999999999999, true, 850m, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);
        }
    }
}
