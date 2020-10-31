using Microsoft.EntityFrameworkCore.Migrations;

namespace MothersBoard.DataAccsess.Migrations
{
    public partial class prodt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(maxLength: 50, nullable: false),
                    ImgPathCompanyLogo = table.Column<string>(nullable: true),
                    ImgPath = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    NumberOfStar = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
