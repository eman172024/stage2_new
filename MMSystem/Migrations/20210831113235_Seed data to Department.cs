using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class SeeddatatoDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[,]
                {
                    { 1, "مكتب رئيس الهيئة ", 0, true },
                    { 22, "الإدارةالعامة للموارد البشرية", 21, true },
                    { 21, "الإدارات العامة الخدمية", 0, true },
                    { 20, "الإدارة العامة للرقابة علي قطاع الخارجية", 14, true },
                    { 19, "الإدارة العامة للرقابة علي القطاعات الاقتصادية والاستثمار", 14, true },
                    { 18, "الإدارة العامة للرقابة علي القطاعات الإنتاجية والبنية الأساسية", 14, true },
                    { 17, "الإدارة العامة للرقابة علي القطاعات الخدمية والأمنية", 14, true },
                    { 16, "الإدارة العامة للرقابة على رئاسة الوزراء", 14, true },
                    { 15, "الإدارة العامة للتحقيق", 14, true },
                    { 14, "الإدارات العامة الفنية والرقابية", 0, true },
                    { 13, "مكتب الشؤون الإعلامية", 10, true },
                    { 12, "مكتب التحري والمعلومات", 10, true },
                    { 11, "مكتب التوثيق وتقنية المعلومات", 10, true },
                    { 10, "مكتب وكيل الهيئة", 0, true },
                    { 9, "وحدة العلاقات الخاصة بمكتب الرئيس", 1, true },
                    { 8, "وحدة الحماية الشخصية", 1, true },
                    { 7, "مكتب المراجعة الداخلية", 1, true },
                    { 6, "مكتب التعاون الدولي والتواضل", 1, true },
                    { 5, "مكتب التخطيط", 1, true },
                    { 4, "مكتب التفتيش وتقييم الاداء", 1, true },
                    { 3, "مكتب الشؤون القانونية ودراسة التشريعات", 1, true },
                    { 2, "مكتب مستشاري رئيس الهيئة", 1, true },
                    { 23, "الإدارةالعامة للشؤون الإدارية والخدمات", 21, true },
                    { 24, "الإدارةالعامة للشؤون المالية", 21, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

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
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
