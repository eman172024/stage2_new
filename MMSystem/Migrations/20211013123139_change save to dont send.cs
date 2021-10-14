using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class changesavetodontsend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 1,
                column: "sent",
                value: "لم ترسل");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 1,
                column: "sent",
                value: "حفظ");
        }
    }
}
