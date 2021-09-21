using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class mailstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailStatuses",
                columns: table => new
                {
                    flag = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flag_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailStatuses", x => x.flag);
                });

            migrationBuilder.InsertData(
                table: "MailStatuses",
                columns: new[] { "flag", "flag_Name", "state" },
                values: new object[,]
                {
                    { 1, "حفظ", true },
                    { 2, "ارسال", true },
                    { 3, "تم القراءة", true },
                    { 4, "تم الرد", true },
                    { 5, "تم الرد من قبلك", true },
                    { 6, "تم السحب", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailStatuses");
        }
    }
}
