using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalAPI.Migrations
{
    public partial class finalv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Users_UserId",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Donations",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_UserId",
                table: "Donations",
                newName: "IX_Donations_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Users_AuthorId",
                table: "Donations",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Users_AuthorId",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Donations",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_AuthorId",
                table: "Donations",
                newName: "IX_Donations_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Users_UserId",
                table: "Donations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
