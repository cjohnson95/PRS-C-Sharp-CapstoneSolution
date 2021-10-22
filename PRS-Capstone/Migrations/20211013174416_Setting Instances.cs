using Microsoft.EntityFrameworkCore.Migrations;

namespace PRS_Capstone.Migrations
{
    public partial class SettingInstances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Requestlines_ProductId",
                table: "Requestlines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Requestlines_RequestId",
                table: "Requestlines",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requestlines_Products_ProductId",
                table: "Requestlines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requestlines_Requests_RequestId",
                table: "Requestlines",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requestlines_Products_ProductId",
                table: "Requestlines");

            migrationBuilder.DropForeignKey(
                name: "FK_Requestlines_Requests_RequestId",
                table: "Requestlines");

            migrationBuilder.DropIndex(
                name: "IX_Requestlines_ProductId",
                table: "Requestlines");

            migrationBuilder.DropIndex(
                name: "IX_Requestlines_RequestId",
                table: "Requestlines");
        }
    }
}
