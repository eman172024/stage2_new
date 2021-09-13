using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class changflagtointegerval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Sends");

            migrationBuilder.DropColumn(
                name: "flag",
                table: "Mails");

            migrationBuilder.AlterColumn<int>(
                name: "flag",
                table: "Sends",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "flag",
                table: "Sends",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Sends",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "flag",
                table: "Mails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
