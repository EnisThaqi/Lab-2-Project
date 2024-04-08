using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2.Migrations
{
    public partial class OrderSizeIdforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_packageSizes",
                table: "packageSizes");

            migrationBuilder.RenameTable(
                name: "packageSizes",
                newName: "Packagesizes");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Packagesizes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packagesizes",
                table: "Packagesizes",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_SizeID",
                table: "orders",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Packagesizes_SizeID",
                table: "orders",
                column: "SizeID",
                principalTable: "Packagesizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Packagesizes_SizeID",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packagesizes",
                table: "Packagesizes");

            migrationBuilder.DropIndex(
                name: "IX_orders_SizeID",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "Packagesizes",
                newName: "packageSizes");

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "packageSizes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_packageSizes",
                table: "packageSizes",
                column: "SizeID");
        }
    }
}
