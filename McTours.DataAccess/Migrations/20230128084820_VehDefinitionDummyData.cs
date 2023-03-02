using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class VehDefinitionDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleDefinition",
                columns: new[] { "Id", "FuelType", "LineCount", "SeatingType", "Utility", "VehicleModelId", "Year" },
                values: new object[] { 1, 2, (short)10, 1, 11, 1, (short)2009 });

            migrationBuilder.InsertData(
                table: "VehicleDefinition",
                columns: new[] { "Id", "FuelType", "LineCount", "SeatingType", "Utility", "VehicleModelId", "Year" },
                values: new object[] { 2, 1, (short)10, 2, 219, 2, (short)2019 });

            migrationBuilder.InsertData(
                table: "VehicleDefinition",
                columns: new[] { "Id", "FuelType", "LineCount", "SeatingType", "Utility", "VehicleModelId", "Year" },
                values: new object[] { 3, 2, (short)10, 1, 75, 2, (short)2012 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
