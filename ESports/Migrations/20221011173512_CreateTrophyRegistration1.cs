using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESports.Migrations
{
    public partial class CreateTrophyRegistration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrophyRegistrations",
                columns: table => new
                {
                    TrophyID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerNIC = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrophyRegistrations", x => x.TrophyID);
                    table.ForeignKey(
                        name: "FK_TrophyRegistrations_Players_PlayerNIC",
                        column: x => x.PlayerNIC,
                        principalTable: "Players",
                        principalColumn: "PlayerNIC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrophyRegistrations_PlayerNIC",
                table: "TrophyRegistrations",
                column: "PlayerNIC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrophyRegistrations");
        }
    }
}
