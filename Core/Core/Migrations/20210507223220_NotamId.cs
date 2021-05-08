using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class NotamId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotamId",
                table: "Notams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotamId",
                table: "Notams");
        }
    }
}
