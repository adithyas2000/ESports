using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESports.Migrations.AppDb
{
    public partial class NewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerNIC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerLName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerAge = table.Column<int>(type: "int", nullable: false),
                    PlayerRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerHand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTeam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerNIC);
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
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrophyRegistrations",
                columns: table => new
                {
                    TrophyID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerNIC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerLName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerAge = table.Column<int>(type: "int", nullable: false),
                    PlayerRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerHand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTeam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrophyRegistrations", x => new { x.TrophyID, x.PlayerNIC });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Trophies");

            migrationBuilder.DropTable(
                name: "TrophyRegistrations");
        }
    }
}
