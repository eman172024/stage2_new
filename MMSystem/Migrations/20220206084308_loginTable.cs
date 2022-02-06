using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class loginTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Time_of_login = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time_of_logout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hour_of_work = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistory", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[] { 10, "اضافة مستخدم " });

            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[] { 11, "  حدف مستخدم" });

            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[] { 12, "  الغاء تفعيل مستخدم" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginHistory");

            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "histortyNames",
                keyColumn: "ID",
                keyValue: 12);
        }
    }
}
