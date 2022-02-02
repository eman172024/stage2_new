using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class adddep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[] { 8, "  اضافة ادارة" });

            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[] { 9, "  حدف ادارة" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 9);
        }
    }
}
