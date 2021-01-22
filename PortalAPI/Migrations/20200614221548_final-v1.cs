using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalAPI.Migrations
{
    public partial class finalv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Donations_DonationId",
                table: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Donations_DonationId",
                table: "Items",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Donations_DonationId",
                table: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Donations_DonationId",
                table: "Items",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
