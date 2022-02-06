using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class changenamefromdeletetoupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 11,
                column: "name",
                value: "تعديل مستخدم");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 11,
                column: "name",
                value: "  حدف مستخدم");
        }
    }
}
