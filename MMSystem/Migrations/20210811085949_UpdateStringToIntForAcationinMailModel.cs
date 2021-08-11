using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class UpdateStringToIntForAcationinMailModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action_Required",
                table: "Mails");

            migrationBuilder.DropColumn(
                name: "action_Requierd",
                table: "Extrenal_Inboxes");

            migrationBuilder.DropColumn(
                name: "action_Requierd",
                table: "External_Mails");

            migrationBuilder.AddColumn<int>(
                name: "action",
                table: "Mails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "action",
                table: "Extrenal_Inboxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "action",
                table: "External_Mails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "action",
                table: "Mails");

            migrationBuilder.DropColumn(
                name: "action",
                table: "Extrenal_Inboxes");

            migrationBuilder.DropColumn(
                name: "action",
                table: "External_Mails");

            migrationBuilder.AddColumn<string>(
                name: "Action_Required",
                table: "Mails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "action_Requierd",
                table: "Extrenal_Inboxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "action_Requierd",
                table: "External_Mails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
