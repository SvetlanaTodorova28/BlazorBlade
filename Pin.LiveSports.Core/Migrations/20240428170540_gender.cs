using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.LiveSports.Core.Migrations
{
    public partial class gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Players");

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 6, 18, 34, 59, 613, DateTimeKind.Local).AddTicks(4760), new DateTime(2024, 8, 4, 18, 34, 59, 613, DateTimeKind.Local).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 25, 18, 34, 59, 613, DateTimeKind.Local).AddTicks(4770), new DateTime(2024, 9, 20, 18, 34, 59, 613, DateTimeKind.Local).AddTicks(4770) });
        }
    }
}
