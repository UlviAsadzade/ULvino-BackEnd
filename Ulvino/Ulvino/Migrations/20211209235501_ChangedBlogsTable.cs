using Microsoft.EntityFrameworkCore.Migrations;

namespace Ulvino.Migrations
{
    public partial class ChangedBlogsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Blogs",
                newName: "Desc5");

            migrationBuilder.AddColumn<string>(
                name: "Desc1",
                table: "Blogs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc2",
                table: "Blogs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc3",
                table: "Blogs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc4",
                table: "Blogs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Desc2",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Desc3",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Desc4",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Desc5",
                table: "Blogs",
                newName: "Desc");
        }
    }
}
