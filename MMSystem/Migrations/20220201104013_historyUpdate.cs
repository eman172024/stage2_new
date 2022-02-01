using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class historyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldValue",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "newValue",
                table: "History",
                newName: "changes");

            migrationBuilder.AddColumn<int>(
                name: "currentUser",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currentUser",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "changes",
                table: "History",
                newName: "newValue");

            migrationBuilder.AddColumn<string>(
                name: "OldValue",
                table: "History",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
