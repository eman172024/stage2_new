using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class stage2_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "resendfrom",
                table: "Sends",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReplyId2",
                table: "Reply_Resources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fromWho",
                table: "Mail_Resourcescs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "section_Notes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    send_ToId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section_Notes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_section_Notes_Sends_send_ToId",
                        column: x => x.send_ToId,
                        principalTable: "Sends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_section_Notes_send_ToId",
                table: "section_Notes",
                column: "send_ToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "section_Notes");

            migrationBuilder.DropColumn(
                name: "resendfrom",
                table: "Sends");

            migrationBuilder.DropColumn(
                name: "ReplyId2",
                table: "Reply_Resources");

            migrationBuilder.DropColumn(
                name: "fromWho",
                table: "Mail_Resourcescs");
        }
    }
}
