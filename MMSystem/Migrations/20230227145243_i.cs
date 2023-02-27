using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_External_Department_Mails_Mail_id",
                table: "External_Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_External_Department",
                table: "External_Department");

            migrationBuilder.RenameTable(
                name: "External_Department",
                newName: "external_Departments");

            migrationBuilder.RenameIndex(
                name: "IX_External_Department_Mail_id",
                table: "external_Departments",
                newName: "IX_external_Departments_Mail_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_external_Departments",
                table: "external_Departments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_external_Departments_Mails_Mail_id",
                table: "external_Departments",
                column: "Mail_id",
                principalTable: "Mails",
                principalColumn: "MailID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_external_Departments_Mails_Mail_id",
                table: "external_Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_external_Departments",
                table: "external_Departments");

            migrationBuilder.RenameTable(
                name: "external_Departments",
                newName: "External_Department");

            migrationBuilder.RenameIndex(
                name: "IX_external_Departments_Mail_id",
                table: "External_Department",
                newName: "IX_External_Department_Mail_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_External_Department",
                table: "External_Department",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_External_Department_Mails_Mail_id",
                table: "External_Department",
                column: "Mail_id",
                principalTable: "Mails",
                principalColumn: "MailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
