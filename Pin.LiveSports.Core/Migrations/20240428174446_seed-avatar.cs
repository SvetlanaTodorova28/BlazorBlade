using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.LiveSports.Core.Migrations
{
    public partial class seedavatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarPicture",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "AvatarPicture",
                value: "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=zorro");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "AvatarPicture",
                value: "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=luke");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "AvatarPicture",
                value: "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=athos");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "AvatarPicture",
                value: "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=porthos");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "AvatarPicture",
                value: "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=Aramis");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "AvatarPicture",
                value: "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&facialHairProbability=0&top%5B%5D=bigHair,bob,bun,curvy,longButNotTooLong,shaggy,shaggyMullet,shavedSides,straightAndStrand,straight01,straight02&seed=joan");

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 6, 19, 44, 46, 37, DateTimeKind.Local).AddTicks(5040), new DateTime(2024, 8, 4, 19, 44, 46, 37, DateTimeKind.Local).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 25, 19, 44, 46, 37, DateTimeKind.Local).AddTicks(5050), new DateTime(2024, 9, 20, 19, 44, 46, 37, DateTimeKind.Local).AddTicks(5050) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPicture",
                table: "Players");

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
    }
}
