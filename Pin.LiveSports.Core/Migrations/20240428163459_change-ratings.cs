using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.LiveSports.Core.Migrations
{
    public partial class changeratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamTournament",
                columns: table => new
                {
                    TeamsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTournament", x => new { x.TeamsId, x.TournamentsId });
                    table.ForeignKey(
                        name: "FK_TeamTournament_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamTournament_Tournaments_TournamentsId",
                        column: x => x.TournamentsId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Duels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FencerAId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FencerBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FencerAPoints = table.Column<int>(type: "int", nullable: false),
                    FencerBPoints = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duels_Players_FencerAId",
                        column: x => x.FencerAId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duels_Players_FencerBId",
                        column: x => x.FencerBId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duels_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Duels_DuelId",
                        column: x => x.DuelId,
                        principalTable: "Duels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CountryCode", "Flag", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000007"), "GB", "https://flagsapi.com/GB/shiny/64.png", "The Screeners" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "FR", "https://flagsapi.com/FR/shiny/64.png", "The Three Musketeers" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "ES", "https://flagsapi.com/ES/shiny/64.png", "Maiden Warrior" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2024, 8, 6, 18, 34, 59, 613, DateTimeKind.Local).AddTicks(4760), "The Grand Duelist Gala", new DateTime(2024, 8, 4, 18, 34, 59, 613, DateTimeKind.Local).AddTicks(4720) },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2024, 9, 25, 18, 34, 59, 613, DateTimeKind.Local).AddTicks(4770), "The Blade Masters Summit", new DateTime(2024, 9, 20, 18, 34, 59, 613, DateTimeKind.Local).AddTicks(4770) }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "Rating", "TeamId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Zorro", 500, new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Luke Skywalker", 300, new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Athos", 800, new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Porthos", 1500, new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Aramis", 1300, new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Joan of Arc", 1900, new Guid("00000000-0000-0000-0000-000000000009") }
                });

            migrationBuilder.InsertData(
                table: "TeamTournament",
                columns: new[] { "TeamsId", "TournamentsId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000011") }
                });

            migrationBuilder.InsertData(
                table: "Duels",
                columns: new[] { "Id", "FencerAId", "FencerAPoints", "FencerBId", "FencerBPoints", "TournamentId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000001"), 0, new Guid("00000000-0000-0000-0000-000000000002"), 0, new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000003"), 0, new Guid("00000000-0000-0000-0000-000000000004"), 0, new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000005"), 0, new Guid("00000000-0000-0000-0000-000000000006"), 0, new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000001"), 0, new Guid("00000000-0000-0000-0000-000000000006"), 0, new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000002"), 0, new Guid("00000000-0000-0000-0000-000000000005"), 0, new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000003"), 0, new Guid("00000000-0000-0000-0000-000000000004"), 0, new Guid("00000000-0000-0000-0000-000000000011") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DuelId",
                table: "Comments",
                column: "DuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Duels_FencerAId",
                table: "Duels",
                column: "FencerAId");

            migrationBuilder.CreateIndex(
                name: "IX_Duels_FencerBId",
                table: "Duels",
                column: "FencerBId");

            migrationBuilder.CreateIndex(
                name: "IX_Duels_TournamentId",
                table: "Duels",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTournament_TournamentsId",
                table: "TeamTournament",
                column: "TournamentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "TeamTournament");

            migrationBuilder.DropTable(
                name: "Duels");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
