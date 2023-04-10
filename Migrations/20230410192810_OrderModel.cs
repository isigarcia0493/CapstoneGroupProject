using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneGroupProject.Migrations
{
    public partial class OrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderViewModel_OrderViewModelOrderID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderViewModelOrderID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderViewModelOrderID",
                table: "OrderDetails");

            migrationBuilder.CreateTable(
                name: "ProductViewModel",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    SupplierID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    IsChecked = table.Column<bool>(nullable: false),
                    OrderQuantity = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: true),
                    OrderViewModelOrderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductViewModel", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_ProductViewModel_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductViewModel_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductViewModel_OrderViewModel_OrderViewModelOrderID",
                        column: x => x.OrderViewModelOrderID,
                        principalTable: "OrderViewModel",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductViewModel_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductViewModel_CategoryID",
                table: "ProductViewModel",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductViewModel_OrderID",
                table: "ProductViewModel",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductViewModel_OrderViewModelOrderID",
                table: "ProductViewModel",
                column: "OrderViewModelOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductViewModel_SupplierID",
                table: "ProductViewModel",
                column: "SupplierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductViewModel");

            migrationBuilder.AddColumn<int>(
                name: "OrderViewModelOrderID",
                table: "OrderDetails",
                type: "int",
                nullable: true);

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
    }
}
