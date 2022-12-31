using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class officeTypeToMail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.AddColumn<string>(
                name: "office_type",
                table: "Mails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "office_type",
                table: "Mails");

            migrationBuilder.InsertData(
                table: "Extrmal_Sections",
                columns: new[] { "id", "Section_Name", "perent", "state", "type" },
                values: new object[,]
                {
                    { 2, "فرع سبها ", 1, true, 1 },
                    { 3, "فرع مصراته ", 1, true, 1 },
                    { 4, "الشركات الوطنية ", 0, true, 2 },
                    { 5, "الشركة العامة للكهرباء  ", 4, true, 2 },
                    { 6, "شركة المياه والصرف الصحي ", 4, true, 2 },
                    { 7, "الشركات الاجنبية ", 0, true, 2 },
                    { 8, "Oil and Gas", 7, true, 2 },
                    { 9, "AVA", 7, true, 2 },
                    { 10, "ذات المسؤولية المحدودة", 0, true, 3 },
                    { 11, "النمو التقني", 10, true, 3 }
                });
        }
    }
}
