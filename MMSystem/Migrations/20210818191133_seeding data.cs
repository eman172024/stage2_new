using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class seedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type_of_mail",
                table: "Sends");

            migrationBuilder.AddColumn<int>(
                name: "type_of_send",
                table: "Sends",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "measures",
                columns: new[] { "MeasuresId", "MeasuresName", "state" },
                values: new object[,]
                {
                    { 1, "للعلم", true },
                    { 2, "للرأي", true },
                    { 3, "للاجراء", true },
                    { 4, "للدراسة", true },
                    { 5, "للاختصاص", true },
                    { 6, "للبحث والاشادة", true },
                    { 7, "لاعداد موقف", true },
                    { 8, "للمتابعة", true },
                    { 9, "للتحقيق", true },
                    { 10, "لامانع", true },
                    { 11, "للاهتمام", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "measures",
                keyColumn: "MeasuresId",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "type_of_send",
                table: "Sends");

            migrationBuilder.AddColumn<string>(
                name: "type_of_mail",
                table: "Sends",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
