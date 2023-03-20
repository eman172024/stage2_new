using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class addfoeaignkeyToExte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "side_id",
                table: "external_Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_external_Departments_side_id",
                table: "external_Departments",
                column: "side_id");

            migrationBuilder.AddForeignKey(
                name: "FK_external_Departments_Extrmal_Sections_side_id",
                table: "external_Departments",
                column: "side_id",
                principalTable: "Extrmal_Sections",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_external_Departments_Extrmal_Sections_side_id",
                table: "external_Departments");

            migrationBuilder.DropIndex(
                name: "IX_external_Departments_side_id",
                table: "external_Departments");

            migrationBuilder.DropColumn(
                name: "side_id",
                table: "external_Departments");
        }
    }
}
