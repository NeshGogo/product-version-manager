using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductVersionManagerBackend.Migrations
{
    public partial class versionfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "ProductVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "ProductVersions");
        }
    }
}
