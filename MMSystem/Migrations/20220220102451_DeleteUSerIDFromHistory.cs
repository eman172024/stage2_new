using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class DeleteUSerIDFromHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "sectionName",
                table: "External_Mails");

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "External_Mails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectorType",
                table: "External_Mails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 11,
                column: "name",
                value: "تعديل مستخدم");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "External_Mails");

            migrationBuilder.DropColumn(
                name: "SectorType",
                table: "External_Mails");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sectionName",
                table: "External_Mails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 11,
                column: "name",
                value: "  تعديل مستخدم");
        }
    }
}
