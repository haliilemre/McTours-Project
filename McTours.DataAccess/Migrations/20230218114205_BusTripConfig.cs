using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class BusTripConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusTrip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    DeppartureCityId = table.Column<int>(type: "int", nullable: false),
                    ArrivalCityId = table.Column<int>(type: "int", nullable: false),
                    EstimatedTravelTime = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "money", nullable: false),
                    BreakTimeDuration = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTrip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusTrip_City_ArrivalCityId",
                        column: x => x.ArrivalCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusTrip_City_DeppartureCityId",
                        column: x => x.DeppartureCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusTrip_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusTrip_ArrivalCityId",
                table: "BusTrip",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrip_DeppartureCityId",
                table: "BusTrip",
                column: "DeppartureCityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrip_VehicleId",
                table: "BusTrip",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusTrip");
        }
    }
}
