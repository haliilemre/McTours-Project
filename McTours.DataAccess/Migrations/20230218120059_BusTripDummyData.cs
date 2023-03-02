using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class BusTripDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BusTrip",
                columns: new[] { "Id", "ArrivalCityId", "BreakTimeDuration", "Date", "DeppartureCityId", "EstimatedTravelTime", "TicketPrice", "VehicleId" },
                values: new object[,]
                {
                    { 1, 2, 30, new DateTime(2023, 3, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 180, 150m, 1 },
                    { 2, 1, 60, new DateTime(2023, 3, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), 3, 360, 200m, 2 },
                    { 3, 5, 90, new DateTime(2023, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, 720, 330m, 3 },
                    { 4, 1, 90, new DateTime(2023, 3, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), 5, 720, 330m, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusTrip",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BusTrip",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BusTrip",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BusTrip",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
