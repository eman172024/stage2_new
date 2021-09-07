using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class dr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userRoles_Administrator_AdministratorUserId",
                table: "userRoles");

            migrationBuilder.DropIndex(
                name: "IX_userRoles_AdministratorUserId",
                table: "userRoles");

            migrationBuilder.DropColumn(
                name: "AdministratorUserId",
                table: "userRoles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "userRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdministratorUserId",
                table: "userRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "userRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_AdministratorUserId",
                table: "userRoles",
                column: "AdministratorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_userRoles_Administrator_AdministratorUserId",
                table: "userRoles",
                column: "AdministratorUserId",
                principalTable: "Administrator",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
