using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiFlightInfo.Migrations
{
    public partial class FlightManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    flightId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    flightSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flightDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flightDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.flightId);
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "flightId", "flightDateTime", "flightDestination", "flightSource" },
                values: new object[] { "SIA606", new DateTime(2023, 11, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), "SEOUL, SOUTH KOREA", "SINGAPORE" });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "flightId", "flightDateTime", "flightDestination", "flightSource" },
                values: new object[] { "BAW304", new DateTime(2023, 10, 6, 12, 23, 30, 0, DateTimeKind.Unspecified), "PARIS, FRANCE", "LONDON, UNITED KINGDOM" });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "flightId", "flightDateTime", "flightDestination", "flightSource" },
                values: new object[] { "TGW24", new DateTime(2023, 12, 3, 20, 5, 15, 0, DateTimeKind.Unspecified), "MELBOURNE, AUSTRALIA", "SINGAPORE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}
