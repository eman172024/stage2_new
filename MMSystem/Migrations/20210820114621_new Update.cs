using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class newUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "classification",
                table: "Mails");

            migrationBuilder.RenameColumn(
                name: "action",
                table: "Mails",
                newName: "clasification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "clasification",
                table: "Mails",
                newName: "action");

            migrationBuilder.AddColumn<string>(
                name: "classification",
                table: "Mails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
