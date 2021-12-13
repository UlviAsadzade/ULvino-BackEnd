using Microsoft.EntityFrameworkCore.Migrations;

namespace Ulvino.Migrations
{
    public partial class SettingTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderLogo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FooterLogo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerSubtitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FooterDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LocationIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HomeIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WorkTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WorkTimeIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Hotline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HotlineImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SupportEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Adress2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TwitterIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FacebookIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    YoutubeIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    YoutubeUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GooglePlusIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GooglePlusUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PinterestIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PinterestUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProcessDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MapUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
