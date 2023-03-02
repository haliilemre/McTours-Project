using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class TicketConfig_V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_BusTripId",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BusTripId_SeatNumber",
                table: "Ticket",
                columns: new[] { "BusTripId", "SeatNumber" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_BusTripId_SeatNumber",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BusTripId",
                table: "Ticket",
                column: "BusTripId");
        }
    }
}
