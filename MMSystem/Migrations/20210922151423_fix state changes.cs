using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class fixstatechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "flag_Name",
                table: "MailStatuses",
                newName: "sent");

            migrationBuilder.AddColumn<string>(
                name: "inbox",
                table: "MailStatuses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 1,
                column: "inbox",
                value: "");

            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 2,
                column: "inbox",
                value: "لم يتم قراءة البريد");

            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 3,
                column: "inbox",
                value: "تم قراءة البريد");

            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 4,
                column: "inbox",
                value: "تم الرد من قيلك ");

            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 5,
                column: "inbox",
                value: "يوجد رد جديد من الادارة المرسلة");

            migrationBuilder.UpdateData(
                table: "MailStatuses",
                keyColumn: "flag",
                keyValue: 6,
                column: "inbox",
                value: "تم سحب البريد من قبلك");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inbox",
                table: "MailStatuses");

            migrationBuilder.RenameColumn(
                name: "sent",
                table: "MailStatuses",
                newName: "flag_Name");
        }
    }
}
