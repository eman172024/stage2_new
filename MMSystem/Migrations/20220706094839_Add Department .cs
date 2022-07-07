using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class AddDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 50,
                column: "DepartmentName",
                value: "فرع غرب طرابلس");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[] { 56, "فرع شرق طرابلس", 0, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 50,
                column: "DepartmentName",
                value: "غرب طرابلس");
        }
    }
}
