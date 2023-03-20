using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class addmail_forwarding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sector_name",
                table: "external_Departments");

            migrationBuilder.DropColumn(
                name: "side_name",
                table: "external_Departments");

            migrationBuilder.AddColumn<int>(
                name: "mail_forwarding",
                table: "external_Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mail_forwarding",
                table: "external_Departments");

            migrationBuilder.AddColumn<string>(
                name: "sector_name",
                table: "external_Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "side_name",
                table: "external_Departments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
