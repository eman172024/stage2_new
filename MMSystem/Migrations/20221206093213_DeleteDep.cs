using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class DeleteDep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DepartmentName",
                value: "مكتب مستشاري رئيس الهيئة");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DepartmentName",
                value: "مكتب المستشارين");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[,]
                {
                    { 3, "الادارة العامة للشؤون الادارية والمالية ", 1, true },
                    { 4, "الادارة العامة للرقابة علي الشركات والمشروعات", 1, true },
                    { 6, "الادارة العامة للرقابة علي المؤسسات العامة", 1, true },
                    { 10, "الادارة العامة للرقابة علي المصارف", 0, true },
                    { 15, "مكتب الرعاية الصحية", 14, true },
                    { 18, "مكتب متابعة الرقم الوطني", 14, true },
                    { 24, "مكتب التدريب", 21, true },
                    { 29, "مكتب الشكاوي والبلاغات   ", 1, true },
                    { 30, "مكتب شؤون الفروع ", 1, true },
                    { 31, "مكتب المتابعة", 1, true },
                    { 33, "الادارة العامة للرقابة علي لجان الازمة واللجان التسييرية والمؤقتة", 1, true }
                });
        }
    }
}
