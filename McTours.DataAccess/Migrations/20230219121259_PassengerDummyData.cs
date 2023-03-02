using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class PassengerDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Passenger",
                columns: new[] { "Id", "BirthDate", "FirstName", "Gender", "IdentityNumber", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1982, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tsubasa", 1, "12345678910", "Ozora" },
                    { 2, new DateTime(1982, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sanae", 2, "12345678910", "Ozora" },
                    { 3, new DateTime(1982, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kojiro", 1, "23456789101", "Hyuga" },
                    { 4, new DateTime(1982, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Genzo", 1, "34567891012", "Wakabayashi" },
                    { 5, new DateTime(1982, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taro", 1, "45678910123", "Misaki" },
                    { 6, new DateTime(1982, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ken", 1, "56789101234", "Wakashimazu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Passenger",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
