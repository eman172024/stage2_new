using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class Addhistorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Transaction",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "History",
                newName: "newValue");

            migrationBuilder.RenameColumn(
                name: "RowTransaction",
                table: "History",
                newName: "userId");

            migrationBuilder.AddColumn<int>(
                name: "HistortyNameID",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mailid",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "histortyNames",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_histortyNames", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "histortyNames",
                columns: new[] { "ID", "name" },
                values: new object[,]
                {
                    { 1, "اضافة بريد" },
                    { 2, " تعديل بريد" },
                    { 3, "حدف بريد" },
                    { 4, "اضافة صورة" },
                    { 5, "حدف صورة" },
                    { 6, "اضافة رد" },
                    { 7, "حذف رد" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_HistortyNameID",
                table: "History",
                column: "HistortyNameID");

            migrationBuilder.AddForeignKey(
                name: "FK_History_histortyNames_HistortyNameID",
                table: "History",
                column: "HistortyNameID",
                principalTable: "histortyNames",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_histortyNames_HistortyNameID",
                table: "History");

            migrationBuilder.DropTable(
                name: "histortyNames");

            migrationBuilder.DropIndex(
                name: "IX_History_HistortyNameID",
                table: "History");

            migrationBuilder.DropColumn(
                name: "HistortyNameID",
                table: "History");

            migrationBuilder.DropColumn(
                name: "mailid",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "History",
                newName: "RowTransaction");

            migrationBuilder.RenameColumn(
                name: "newValue",
                table: "History",
                newName: "User");

            migrationBuilder.AddColumn<string>(
                name: "Transaction",
                table: "History",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
