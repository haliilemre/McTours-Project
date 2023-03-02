using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class VehicleDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "PlateNumber", "RegistrationDate", "RegistrationNumber", "VehicleDefinitionId" },
                values: new object[] { 1, "34AST001", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATS3030121AK", 1 });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "PlateNumber", "RegistrationDate", "RegistrationNumber", "VehicleDefinitionId" },
                values: new object[] { 2, "34UK080", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATS3546781AK", 2 });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "PlateNumber", "RegistrationDate", "RegistrationNumber", "VehicleDefinitionId" },
                values: new object[] { 3, "34CRF19", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATS0000459AK", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
