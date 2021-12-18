using Microsoft.EntityFrameworkCore.Migrations;

namespace Ulvino.Migrations
{
    public partial class ProductImageAddOrderItemTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "OrderItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "OrderItems");
        }
    }
}
