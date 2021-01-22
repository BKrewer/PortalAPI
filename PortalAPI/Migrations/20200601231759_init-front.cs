using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalAPI.Migrations
{
    public partial class initfront : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Users",
                nullable: false,
                defaultValue: "");
        }
    }
}
