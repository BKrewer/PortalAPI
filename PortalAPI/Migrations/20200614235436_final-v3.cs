using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalAPI.Migrations
{
    public partial class finalv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Donations_DonationId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Donations_DonationId",
                table: "Items",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Donations_DonationId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Donations");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Donations_DonationId",
                table: "Items",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
