using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.LiveSports.Core.Migrations
{
    public partial class requiretournament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 27, 19, 38, 38, 838, DateTimeKind.Local).AddTicks(8810), new DateTime(2024, 8, 25, 19, 38, 38, 838, DateTimeKind.Local).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 16, 19, 38, 38, 838, DateTimeKind.Local).AddTicks(8820), new DateTime(2024, 10, 11, 19, 38, 38, 838, DateTimeKind.Local).AddTicks(8810) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 27, 19, 30, 8, 372, DateTimeKind.Local).AddTicks(9390), new DateTime(2024, 8, 25, 19, 30, 8, 372, DateTimeKind.Local).AddTicks(9340) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 16, 19, 30, 8, 372, DateTimeKind.Local).AddTicks(9390), new DateTime(2024, 10, 11, 19, 30, 8, 372, DateTimeKind.Local).AddTicks(9390) });
        }
    }
}
