using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class External_Department : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "External_Department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sector_number = table.Column<int>(type: "int", nullable: false),
                    sector_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail_id = table.Column<int>(type: "int", nullable: false),
                    insert_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_External_Department", x => x.id);
                    table.ForeignKey(
                        name: "FK_External_Department_Mails_Mail_id",
                        column: x => x.Mail_id,
                        principalTable: "Mails",
                        principalColumn: "MailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_External_Department_Mail_id",
                table: "External_Department",
                column: "Mail_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "External_Department");
        }
    }
}
