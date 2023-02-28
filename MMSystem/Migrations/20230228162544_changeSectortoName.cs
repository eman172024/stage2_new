using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class changeSectortoName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "department_number",
                table: "external_Departments",
                newName: "side_number");

            migrationBuilder.RenameColumn(
                name: "department_name",
                table: "external_Departments",
                newName: "side_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "side_number",
                table: "external_Departments",
                newName: "department_number");

            migrationBuilder.RenameColumn(
                name: "side_name",
                table: "external_Departments",
                newName: "department_name");
        }
    }
}
