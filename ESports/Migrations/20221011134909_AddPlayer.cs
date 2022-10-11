using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESports.Migrations
{
    public partial class AddPlayer : Migration
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
                    PlayerHand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerNIC);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
