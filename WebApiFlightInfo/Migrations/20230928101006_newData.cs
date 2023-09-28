using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiFlightInfo.Migrations
{
    public partial class newData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "flightId", "flightDateTime", "flightDestination", "flightSource" },
                values: new object[] { "EVA218", new DateTime(2022, 5, 17, 15, 5, 15, 0, DateTimeKind.Unspecified), "TAIPEI, TAIWAN", "SEPANG, MALAYSIA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "flightId",
                keyValue: "EVA218");
        }
    }
}
