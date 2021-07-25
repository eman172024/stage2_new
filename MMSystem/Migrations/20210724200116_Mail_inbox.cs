using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class Mail_inbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Extrmal_Section",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Section_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    number_of_mail = table.Column<int>(type: "int", nullable: false),
                    perent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extrmal_Section", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    MailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message_Number = table.Column<int>(type: "int", nullable: false),
                    Management_Id = table.Column<int>(type: "int", nullable: false),
                    currentYear = table.Column<int>(type: "int", nullable: false),
                    Date_Of_Mail = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mail_Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    classification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genaral_inbox_Number = table.Column<int>(type: "int", nullable: false),
                    Genaral_inbox_year = table.Column<int>(type: "int", nullable: false),
                    Action_Required = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.MailID);
                    table.ForeignKey(
                        name: "FK_Mails_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "External_Mails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailID = table.Column<int>(type: "int", nullable: false),
                    Sectionid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_External_Mails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_External_Mails_Extrmal_Section_Sectionid",
                        column: x => x.Sectionid,
                        principalTable: "Extrmal_Section",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_External_Mails_Mails_MailID",
                        column: x => x.MailID,
                        principalTable: "Mails",
                        principalColumn: "MailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Extrenal_Inboxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    to = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Send_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MailID = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    section_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    action_Requierd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extrenal_Inboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extrenal_Inboxes_Extrmal_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Extrmal_Section",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Extrenal_Inboxes_Mails_MailID",
                        column: x => x.MailID,
                        principalTable: "Mails",
                        principalColumn: "MailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_External_Mails_MailID",
                table: "External_Mails",
                column: "MailID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_External_Mails_Sectionid",
                table: "External_Mails",
                column: "Sectionid");

            migrationBuilder.CreateIndex(
                name: "IX_Extrenal_Inboxes_MailID",
                table: "Extrenal_Inboxes",
                column: "MailID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Extrenal_Inboxes_SectionId",
                table: "Extrenal_Inboxes",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Mails_userId",
                table: "Mails",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "External_Mails");

            migrationBuilder.DropTable(
                name: "Extrenal_Inboxes");

            migrationBuilder.DropTable(
                name: "Extrmal_Section");

            migrationBuilder.DropTable(
                name: "Mails");
        }
    }
}
