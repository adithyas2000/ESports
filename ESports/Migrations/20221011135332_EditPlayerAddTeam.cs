using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESports.Migrations
{
    public partial class EditPlayerAddTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentTeam",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTeam",
                table: "Players");
        }
    }
}
