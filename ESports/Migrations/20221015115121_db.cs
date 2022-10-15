using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESports.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayersBids",
                columns: table => new
                {
                    TrophyID = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    BidAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersBids", x => new { x.TrophyID, x.TeamId });
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trophies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrophyRegistrations",
                columns: table => new
                {
                    TrophyID = table.Column<int>(type: "int", nullable: false),
                    PlayerNIC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerLName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerAge = table.Column<int>(type: "int", nullable: false),
                    PlayerRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerHand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseFee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrophyRegistrations", x => new { x.TrophyID, x.PlayerNIC });
                });

            migrationBuilder.CreateTable(
                name: "TrophyTeams",
                columns: table => new
                {
                    TrophyID = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaxPrice = table.Column<int>(type: "int", nullable: false),
                    SpentAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrophyTeams", x => new { x.TrophyID, x.TeamId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersBids");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Trophies");

            migrationBuilder.DropTable(
                name: "TrophyRegistrations");

            migrationBuilder.DropTable(
                name: "TrophyTeams");
        }
    }
}
