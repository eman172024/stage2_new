using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class Last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_External_Mails_Extrmal_Section_Sectionid",
                table: "External_Mails");

            migrationBuilder.DropForeignKey(
                name: "FK_Extrenal_Inboxes_Extrmal_Section_SectionId",
                table: "Extrenal_Inboxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Extrmal_Section",
                table: "Extrmal_Section");

            migrationBuilder.RenameTable(
                name: "Extrmal_Section",
                newName: "Extrmal_Sections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Extrmal_Sections",
                table: "Extrmal_Sections",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Sends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailID = table.Column<int>(type: "int", nullable: false),
                    to = table.Column<int>(type: "int", nullable: false),
                    type_of_mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Send_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    flag = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    time_of_read = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sends_Mails_MailID",
                        column: x => x.MailID,
                        principalTable: "Mails",
                        principalColumn: "MailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ReplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    send_To_Id = table.Column<int>(type: "int", nullable: false),
                    send_ToId = table.Column<int>(type: "int", nullable: true),
                    mail_detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_Replies_Sends_send_ToId",
                        column: x => x.send_ToId,
                        principalTable: "Sends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reply_Resources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyId = table.Column<int>(type: "int", nullable: false),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply_Resources", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reply_Resources_Replies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Replies",
                        principalColumn: "ReplyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_send_ToId",
                table: "Replies",
                column: "send_ToId");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_Resources_ReplyId",
                table: "Reply_Resources",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sends_MailID",
                table: "Sends",
                column: "MailID");

            migrationBuilder.AddForeignKey(
                name: "FK_External_Mails_Extrmal_Sections_Sectionid",
                table: "External_Mails",
                column: "Sectionid",
                principalTable: "Extrmal_Sections",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Extrenal_Inboxes_Extrmal_Sections_SectionId",
                table: "Extrenal_Inboxes",
                column: "SectionId",
                principalTable: "Extrmal_Sections",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_External_Mails_Extrmal_Sections_Sectionid",
                table: "External_Mails");

            migrationBuilder.DropForeignKey(
                name: "FK_Extrenal_Inboxes_Extrmal_Sections_SectionId",
                table: "Extrenal_Inboxes");

            migrationBuilder.DropTable(
                name: "Reply_Resources");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Sends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Extrmal_Sections",
                table: "Extrmal_Sections");

            migrationBuilder.RenameTable(
                name: "Extrmal_Sections",
                newName: "Extrmal_Section");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Extrmal_Section",
                table: "Extrmal_Section",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_External_Mails_Extrmal_Section_Sectionid",
                table: "External_Mails",
                column: "Sectionid",
                principalTable: "Extrmal_Section",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Extrenal_Inboxes_Extrmal_Section_SectionId",
                table: "Extrenal_Inboxes",
                column: "SectionId",
                principalTable: "Extrmal_Section",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
