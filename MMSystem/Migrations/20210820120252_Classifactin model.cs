using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class Classifactinmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clasifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clasifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "clasifications",
                columns: new[] { "Id", "Name", "state" },
                values: new object[,]
                {
                    { 1, "شكوى", true },
                    { 2, "مقال صحفي", true },
                    { 3, "ادارية", true },
                    { 4, "قرارات", true },
                    { 5, "اجتماعات", true },
                    { 6, "اخرى", true },
                    { 7, "تعميم", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clasifications");
        }
    }
}
