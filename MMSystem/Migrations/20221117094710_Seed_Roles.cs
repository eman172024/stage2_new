using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class Seed_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "code", "state" },
                values: new object[,]
                {
                    { 20, "تصوير داخلي", "t", true },
                    { 21, "تصوير  صادر خارجي", "u", true },
                    { 22, "تصوير وارد خارجي", "v", true },
                    { 23, "تعديل الداخلي", "w", true },
                    { 24, "تعديل وارد خارجي", "x", true },
                    { 25, "تعديل صادر خارجي", "y", true },
                    { 26, " ارسال بريد داخلي", "z", true },
                    { 27, " ارسال وارد خارجي", "aa", true },
                    { 28, " ارسال صادر خارجي", "ba", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 28);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "code", "state" },
                values: new object[] { 8, "  ارسال البريد بعد الحفظ ", "h", true });
        }
    }
}
