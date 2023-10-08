using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class sections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[] { 90, "قسم البرمجة  ", 17, true });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[] { 91, "قسم الشبكات", 17, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[] { 57, "قسم البرمجة  ", 17, true });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[] { 58, "قسم الشبكات", 17, true });
        }
    }
}
