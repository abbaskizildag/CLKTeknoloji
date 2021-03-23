using Microsoft.EntityFrameworkCore.Migrations;

namespace ClkTeknoloji.Server.Data.Migrations
{
    public partial class servicesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ServiceId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ServiceId",
                table: "Products",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ServiceId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ServiceId",
                table: "Products",
                column: "ServiceId",
                unique: true);
        }
    }
}
