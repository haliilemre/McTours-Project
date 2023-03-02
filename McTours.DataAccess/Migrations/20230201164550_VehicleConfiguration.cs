using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class VehicleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleDefinitionId = table.Column<int>(type: "int", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleDefinition_VehicleDefinitionId",
                        column: x => x.VehicleDefinitionId,
                        principalTable: "VehicleDefinition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleDefinitionId",
                table: "Vehicle",
                column: "VehicleDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
