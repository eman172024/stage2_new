using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class Rbetweenusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "userRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_UserId",
                table: "userRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_userRoles_Administrator_UserId",
                table: "userRoles",
                column: "UserId",
                principalTable: "Administrator",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userRoles_Administrator_UserId",
                table: "userRoles");

            migrationBuilder.DropIndex(
                name: "IX_userRoles_UserId",
                table: "userRoles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "userRoles");
        }
    }
}
