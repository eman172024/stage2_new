using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class fixextanaltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "entity_reference_number",
                table: "Extrenal_Inboxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "procedure_type",
                table: "Extrenal_Inboxes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "entity_reference_number",
                table: "Extrenal_Inboxes");

            migrationBuilder.DropColumn(
                name: "procedure_type",
                table: "Extrenal_Inboxes");
        }
    }
}
