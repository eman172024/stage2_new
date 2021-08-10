using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class changeSectionToParint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number_of_mail",
                table: "Extrmal_Sections");

            migrationBuilder.DropColumn(
                name: "NumberOfPhotos",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Message_Number",
                table: "Mails",
                newName: "Mail_Number");

            migrationBuilder.RenameColumn(
                name: "numberOfMail",
                table: "Departments",
                newName: "perent");

            migrationBuilder.AddColumn<bool>(
                name: "state",
                table: "Mails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "state",
                table: "Mails");

            migrationBuilder.RenameColumn(
                name: "Mail_Number",
                table: "Mails",
                newName: "Message_Number");

            migrationBuilder.RenameColumn(
                name: "perent",
                table: "Departments",
                newName: "numberOfMail");

            migrationBuilder.AddColumn<int>(
                name: "number_of_mail",
                table: "Extrmal_Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPhotos",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
