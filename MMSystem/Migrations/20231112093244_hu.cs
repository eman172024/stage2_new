using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class hu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[] { 26, "حفظ اعادة توجيه البريد" });

            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[] { 27, "تعديل اعادة توجيه البريد " });

            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[] { 28, "ارسال اعادة توجيه البريد " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 28);
        }
    }
}
