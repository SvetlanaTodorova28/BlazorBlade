using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.LiveSports.Core.Migrations
{
    public partial class seedgendre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "Gender", "IsFemale", "IsMale" },
                values: new object[] { 1, true, false });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 6, 19, 25, 43, 70, DateTimeKind.Local).AddTicks(1030), new DateTime(2024, 8, 4, 19, 25, 43, 70, DateTimeKind.Local).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 25, 19, 25, 43, 70, DateTimeKind.Local).AddTicks(1040), new DateTime(2024, 9, 20, 19, 25, 43, 70, DateTimeKind.Local).AddTicks(1040) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "Gender", "IsFemale", "IsMale" },
                values: new object[] { 0, false, true });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 6, 19, 21, 38, 629, DateTimeKind.Local).AddTicks(9040), new DateTime(2024, 8, 4, 19, 21, 38, 629, DateTimeKind.Local).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 25, 19, 21, 38, 629, DateTimeKind.Local).AddTicks(9050), new DateTime(2024, 9, 20, 19, 21, 38, 629, DateTimeKind.Local).AddTicks(9050) });
        }
    }
}
