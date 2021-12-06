using Microsoft.EntityFrameworkCore.Migrations;

namespace Ulvino.Migrations
{
    public partial class CustomersTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
