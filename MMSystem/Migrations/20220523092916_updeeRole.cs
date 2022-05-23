using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class updeeRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                columns: new[] { "Name", "code" },
                values: new object[] { "الصادر", "a" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                columns: new[] { "Name", "code" },
                values: new object[] { "اضافة بريد جديد", "b" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                columns: new[] { "Name", "code" },
                values: new object[] { "اضافة بريد داخلي", "c" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                columns: new[] { "Name", "code" },
                values: new object[] { "اضافة بريد وارد خارجي", "d" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 5,
                columns: new[] { "Name", "code" },
                values: new object[] { "اضافة بريد صادر خارجي", "e" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 6,
                columns: new[] { "Name", "code" },
                values: new object[] { " الرد علي الصادر", "f" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 7,
                columns: new[] { "Name", "code" },
                values: new object[] { " عرض الصورة الصادرة", "g" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 8,
                columns: new[] { "Name", "code" },
                values: new object[] { "  ارسال البريد بعد الحفظ ", "h" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 9,
                columns: new[] { "Name", "code" },
                values: new object[] { "حذف البريد", "i" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 10,
                columns: new[] { "Name", "code" },
                values: new object[] { "الاستلام", "j" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 11,
                columns: new[] { "Name", "code" },
                values: new object[] { "السحب", "k" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 12,
                columns: new[] { "Name", "code" },
                values: new object[] { "الاحصائيات", "l" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 13,
                columns: new[] { "Name", "code" },
                values: new object[] { "تقارير المتابعة", "m" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 14,
                columns: new[] { "Name", "code" },
                values: new object[] { "الوارد", "n" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 15,
                columns: new[] { "Name", "code" },
                values: new object[] { "البحث في البريد الداخلي", "o" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 16,
                columns: new[] { "Name", "code" },
                values: new object[] { "البحث في البريد الوارد الخارجي", "p" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 17,
                columns: new[] { "Name", "code" },
                values: new object[] { "البحث في البريد صادر الخارجي", "q" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 18,
                columns: new[] { "Name", "code" },
                values: new object[] { "الرد علي الوارد", "r" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 19,
                columns: new[] { "Name", "code" },
                values: new object[] { "عرض الصورة الواردة", "s" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                columns: new[] { "Name", "code" },
                values: new object[] { "الإطلاع على السري", "t" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                columns: new[] { "Name", "code" },
                values: new object[] { "استخدام الوارد الخارجي", "a" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                columns: new[] { "Name", "code" },
                values: new object[] { "ارسال البريد الى", "b" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                columns: new[] { "Name", "code" },
                values: new object[] { "الإطلاع على التقرير الإحصائى", "c" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 5,
                columns: new[] { "Name", "code" },
                values: new object[] { "الصادر الجديد", "d" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 6,
                columns: new[] { "Name", "code" },
                values: new object[] { "كتابة اجراءالأمين للرسالة", "e" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 7,
                columns: new[] { "Name", "code" },
                values: new object[] { "الإطلاع على تقرير المتابعة", "f" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 8,
                columns: new[] { "Name", "code" },
                values: new object[] { "الاستلام والسحب", "g" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 9,
                columns: new[] { "Name", "code" },
                values: new object[] { "عرض الصورة", "h" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 10,
                columns: new[] { "Name", "code" },
                values: new object[] { "الإطلاع على الوارد الجديد", "i" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 11,
                columns: new[] { "Name", "code" },
                values: new object[] { "استخدام الصادر الخارجي", "j" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 12,
                columns: new[] { "Name", "code" },
                values: new object[] { "الإطلاع على الردود السابقة", "k" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 13,
                columns: new[] { "Name", "code" },
                values: new object[] { "اعادة الارسال", "l" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 14,
                columns: new[] { "Name", "code" },
                values: new object[] { "الرد على الوارد", "m" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 15,
                columns: new[] { "Name", "code" },
                values: new object[] { "ردود الإدارات الفرعية", "n" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 16,
                columns: new[] { "Name", "code" },
                values: new object[] { "استخدام البريد الداخلي", "o" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 17,
                columns: new[] { "Name", "code" },
                values: new object[] { "الداخلي", "p" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 18,
                columns: new[] { "Name", "code" },
                values: new object[] { "وارد خارجي", "q" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 19,
                columns: new[] { "Name", "code" },
                values: new object[] { "استخدام الصادر الخارجي", "r" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "code", "state" },
                values: new object[] { 20, "حذف بريد", "s", true });
        }
    }
}
