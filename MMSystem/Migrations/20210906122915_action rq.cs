using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class actionrq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "action_required_by_the_entity",
                table: "Extrmal_Sections");

            migrationBuilder.AddColumn<string>(
                name: "action_required_by_the_entity",
                table: "External_Mails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "action_required_by_the_entity",
                table: "External_Mails");

            migrationBuilder.AddColumn<string>(
                name: "action_required_by_the_entity",
                table: "Extrmal_Sections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
