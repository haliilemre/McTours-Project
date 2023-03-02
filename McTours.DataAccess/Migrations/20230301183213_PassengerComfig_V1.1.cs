using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class PassengerComfig_V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdentityNumber",
                value: "12345678550");

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_IdentityNumber",
                table: "Passenger",
                column: "IdentityNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passenger_IdentityNumber",
                table: "Passenger");

            migrationBuilder.UpdateData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdentityNumber",
                value: "12345678910");
        }
    }
}
