using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class chngename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 2,
                column: "sent",
                value: "لم تقرأ");

            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 3,
                column: "sent",
                value: "قرأت ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 2,
                column: "sent",
                value: "ارسال");

            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 3,
                column: "sent",
                value: "تم القراءة");
        }
    }
}
