using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class addnewvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 11,
                column: "name",
                value: "  تعديل مستخدم");

            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[] { 13, " تم عرض الصورة " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 11,
                column: "name",
                value: "تعديل مستخدم");
        }
    }
}
