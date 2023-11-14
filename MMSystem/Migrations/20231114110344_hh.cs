using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class hh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "resended",
                table: "Mails");

            migrationBuilder.AddColumn<bool>(
                name: "resended",
                table: "Sends",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "resended",
                table: "Sends");

            migrationBuilder.AddColumn<bool>(
                name: "resended",
                table: "Mails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
