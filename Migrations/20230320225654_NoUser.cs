using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneGroupProject.Migrations
{
    public partial class NoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_ID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ID",
                table: "Employees",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_ID",
                table: "Employees",
                column: "ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
