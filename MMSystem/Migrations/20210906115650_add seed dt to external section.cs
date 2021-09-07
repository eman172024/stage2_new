using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class addseeddttoexternalsection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "action_required_by_the_entity",
                table: "Extrmal_Sections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Extrmal_Sections",
                columns: new[] { "id", "Section_Name", "action_required_by_the_entity", "perent", "state", "type" },
                values: new object[,]
                {
                    { 1, "فروع الهيئة ", null, 0, true, 1 },
                    { 2, "فرغ سبها ", null, 1, true, 1 },
                    { 3, "فرع مصراته ", null, 1, true, 1 },
                    { 4, "الشركات الوطنية ", null, 0, true, 2 },
                    { 5, "الشركة العامة للكهرباء  ", null, 4, true, 2 },
                    { 6, "شركة المياه والصرف الصحي ", null, 4, true, 2 },
                    { 7, "الشركات الاجنبية ", null, 0, true, 2 },
                    { 8, "Oil and Gas", null, 7, true, 2 },
                    { 9, "AVA", null, 7, true, 2 },
                    { 10, "ذات المسؤولية المحدودة", null, 0, true, 3 },
                    { 11, "النمو التقني", null, 10, true, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Extrmal_Sections",
                keyColumn: "id",
                keyValue: 1);

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

            migrationBuilder.DropColumn(
                name: "action_required_by_the_entity",
                table: "Extrmal_Sections");
        }
    }
}
