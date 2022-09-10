using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesManagement.Migrations
{
    public partial class FixRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_Sales_SaleId",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Salesmen_SaleId",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Salesmen");

            migrationBuilder.AddColumn<int>(
                name: "SalesmanId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SalesmanId",
                table: "Sales",
                column: "SalesmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Salesmen_SalesmanId",
                table: "Sales",
                column: "SalesmanId",
                principalTable: "Salesmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Salesmen_SalesmanId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_SalesmanId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SalesmanId",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "Salesmen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_SaleId",
                table: "Salesmen",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_Sales_SaleId",
                table: "Salesmen",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
