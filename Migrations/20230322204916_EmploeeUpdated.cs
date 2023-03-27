using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneGroupProject.Migrations
{
    public partial class EmploeeUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderViewModelOrderID",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "OrderViewModel",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(20,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderViewModel", x => x.OrderID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderViewModelOrderID",
                table: "OrderDetails",
                column: "OrderViewModelOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderViewModel_OrderViewModelOrderID",
                table: "OrderDetails",
                column: "OrderViewModelOrderID",
                principalTable: "OrderViewModel",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderViewModel_OrderViewModelOrderID",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderViewModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderViewModelOrderID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderViewModelOrderID",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 50);
        }
    }
}
