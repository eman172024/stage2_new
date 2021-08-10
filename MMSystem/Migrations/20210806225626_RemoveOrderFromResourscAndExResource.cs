using Microsoft.EntityFrameworkCore.Migrations;

namespace MMSystem.Migrations
{
    public partial class RemoveOrderFromResourscAndExResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order",
                table: "Reply_Resources");

            migrationBuilder.DropColumn(
                name: "order",
                table: "Mail_Resourcescs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order",
                table: "Reply_Resources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "order",
                table: "Mail_Resourcescs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
