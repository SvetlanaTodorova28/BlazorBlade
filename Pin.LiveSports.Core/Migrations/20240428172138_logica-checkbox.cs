using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.LiveSports.Core.Migrations
{
    public partial class logicacheckbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFemale",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "IsMale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "IsMale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "IsMale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "IsMale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "IsMale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "IsMale",
                value: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFemale",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "Players");

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 6, 19, 5, 40, 713, DateTimeKind.Local).AddTicks(9970), new DateTime(2024, 8, 4, 19, 5, 40, 713, DateTimeKind.Local).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 25, 19, 5, 40, 713, DateTimeKind.Local).AddTicks(9980), new DateTime(2024, 9, 20, 19, 5, 40, 713, DateTimeKind.Local).AddTicks(9980) });
        }
    }
}
