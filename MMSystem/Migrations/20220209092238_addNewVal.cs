using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class addNewVal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[,]
                {
                    { 15, " قراءة البريد" },
                    { 16, " مرفقات" },
                    { 17, " عدد النسخ" },
                    { 18, "طباعة حافظة" },
                    { 19, "تسجيل الدخول" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 19);
        }
    }
}
