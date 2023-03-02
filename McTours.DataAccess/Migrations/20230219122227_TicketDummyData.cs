using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class TicketDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "BusTripId", "PassengerId", "Price", "SeatNumber" },
                values: new object[] { 1, 1, 1, 180m, (short)1 });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "BusTripId", "PassengerId", "Price", "SeatNumber" },
                values: new object[] { 2, 1, 2, 180m, (short)2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
