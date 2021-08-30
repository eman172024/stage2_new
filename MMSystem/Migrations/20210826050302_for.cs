using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class @for : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Sends_send_ToId",
                table: "Replies");

            migrationBuilder.AlterColumn<int>(
                name: "send_ToId",
                table: "Replies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Sends_send_ToId",
                table: "Replies",
                column: "send_ToId",
                principalTable: "Sends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Sends_send_ToId",
                table: "Replies");

            migrationBuilder.AlterColumn<int>(
                name: "send_ToId",
                table: "Replies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Sends_send_ToId",
                table: "Replies",
                column: "send_ToId",
                principalTable: "Sends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
