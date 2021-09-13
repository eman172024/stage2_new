using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class addflagtomail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail_Type",
                table: "Mails");

            migrationBuilder.AddColumn<int>(
                name: "flag",
                table: "Mails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "flag",
                table: "Mails");

            migrationBuilder.AddColumn<string>(
                name: "Mail_Type",
                table: "Mails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
