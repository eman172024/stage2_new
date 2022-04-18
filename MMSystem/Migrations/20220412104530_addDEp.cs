using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class addDEp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

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
                keyValue: 23);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DepartmentName",
                value: "الادارة العامة للتحقيق ");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DepartmentName", "perent" },
                values: new object[] { "لجنة الحضور والانصراف", 0 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentName",
                value: "الادارة العامة للشؤون الادارية والمالية ");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DepartmentName",
                value: "الادارة العامة للرقابة علي الشركات والمشروعات");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DepartmentName",
                value: "الادارة العامة للرقابة علي رئاسة الوزراء");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DepartmentName",
                value: "الادارة العامة للرقابة علي المؤسسات العامة");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DepartmentName",
                value: "مكتب المستشارين");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "DepartmentName",
                value: "الادارة العامة للرقابة علي المصارف");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                column: "DepartmentName",
                value: "مكتب المراجعة  الداخلية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                column: "DepartmentName",
                value: "مكتب التفتيش وتقييم الاداء ");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                column: "DepartmentName",
                value: "مكتب الرعاية الصحية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "DepartmentName",
                value: "مكتب التخطيط");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                column: "DepartmentName",
                value: "مكتب التوثيق وتقنية المعلومات");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 18,
                column: "DepartmentName",
                value: "مكتب متابعة الرقم الوطني");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 19,
                column: "DepartmentName",
                value: "مكتب المحفوظات ");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20,
                column: "DepartmentName",
                value: "مكتب الشؤون القانونية ودراسة التشريعات");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 21,
                column: "DepartmentName",
                value: "مكتب رئيس الهيئة");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 22,
                column: "DepartmentName",
                value: "مكتب وكيل الهيئة");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 24,
                column: "DepartmentName",
                value: "مكتب التدريب");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 25,
                column: "DepartmentName",
                value: "مكتب الشؤون الاعلامية");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[,]
                {
                    { 54, "لجنة ربط الفروع ", 0, true },
                    { 55, "لجنة متابعة تنفيد مبني الهيئة   ", 0, true },
                    { 53, "فرع الزنتان", 0, true },
                    { 51, "فرع مصراته", 14, true },
                    { 28, "لجنة صندوق العاملين", 1, true },
                    { 29, "مكتب الشكاوي والبلاغات   ", 1, true },
                    { 30, "مكتب شؤون الفروع ", 1, true },
                    { 31, "مكتب المتابعة", 1, true },
                    { 32, "مكتب التعاون الدولي والتواصل", 1, true },
                    { 33, "الادارة العامة للرقابة علي لجان الازمة واللجان التسييرية والمؤقتة", 1, true },
                    { 34, " وحدة الحماية الشخصية", 1, true },
                    { 35, "وحدة العلاقات الخاصة بمكتب الرئيس", 1, true },
                    { 52, "فرع ترهونة", 14, true },
                    { 36, "مكتب التحري والمعلومات", 10, true },
                    { 39, "الإدارة العامة للرقابة علي القطاعات الإنتاجية والبنية الأساسية", 14, true },
                    { 40, "الإدارة العامة للرقابة علي القطاعات الاقتصادية والاستثمار", 14, true },
                    { 41, "الإدارةالعامة للموارد البشرية", 21, true },
                    { 42, "الإدارةالعامة للشؤون الإدارية والخدمات", 21, true },
                    { 43, "الإدارةالعامة للشؤون المالية", 21, true },
                    { 44, "لجنة الموقع", 10, true },
                    { 49, "فرع العزيزية", 0, true },
                    { 50, "غرب طرابلس", 14, true }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[] { 38, "الإدارة العامة للرقابة علي القطاعات الخدمية والأمنية", 14, true });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[] { 26, "الادارة العامة للرقابة الخارجية ", 0, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 28);

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
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DepartmentName",
                value: "مكتب رئيس الهيئة ");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DepartmentName", "perent" },
                values: new object[] { "مكتب مستشاري رئيس الهيئة", 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentName",
                value: "مكتب الشؤون القانونية ودراسة التشريعات");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DepartmentName",
                value: "مكتب التفتيش وتقييم الاداء");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DepartmentName",
                value: "مكتب التخطيط");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DepartmentName",
                value: "مكتب التعاون الدولي والتواضل");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DepartmentName",
                value: "وحدة الحماية الشخصية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "DepartmentName",
                value: "مكتب وكيل الهيئة");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                column: "DepartmentName",
                value: "مكتب الشؤون الإعلامية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                column: "DepartmentName",
                value: "الإدارات العامة الفنية والرقابية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                column: "DepartmentName",
                value: "الإدارة العامة للتحقيق");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "DepartmentName",
                value: "الإدارة العامة للرقابة على رئاسة الوزراء");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                column: "DepartmentName",
                value: "الإدارة العامة للرقابة علي القطاعات الخدمية والأمنية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 18,
                column: "DepartmentName",
                value: "الإدارة العامة للرقابة علي القطاعات الإنتاجية والبنية الأساسية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 19,
                column: "DepartmentName",
                value: "الإدارة العامة للرقابة علي القطاعات الاقتصادية والاستثمار");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20,
                column: "DepartmentName",
                value: "الإدارة العامة للرقابة علي قطاع الخارجية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 21,
                column: "DepartmentName",
                value: "الإدارات العامة الخدمية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 22,
                column: "DepartmentName",
                value: "الإدارةالعامة للموارد البشرية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 24,
                column: "DepartmentName",
                value: "الإدارةالعامة للشؤون المالية");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 25,
                column: "DepartmentName",
                value: "المحفوظات");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "perent", "state" },
                values: new object[,]
                {
                    { 12, "مكتب التحري والمعلومات", 10, true },
                    { 11, "مكتب التوثيق وتقنية المعلومات", 10, true },
                    { 9, "وحدة العلاقات الخاصة بمكتب الرئيس", 1, true },
                    { 23, "الإدارةالعامة للشؤون الإدارية والخدمات", 21, true },
                    { 7, "مكتب المراجعة الداخلية", 1, true }
                });
        }
    }
}
