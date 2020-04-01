using Microsoft.EntityFrameworkCore.Migrations;

namespace kennel_bambino.web.Data.Migrations
{
    public partial class AddCarouselDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carousels",
                columns: table => new
                {
                    CarouselId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(maxLength: 75, nullable: false),
                    Alt = table.Column<string>(maxLength: 75, nullable: false),
                    Number = table.Column<byte>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousels", x => x.CarouselId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carousels");
        }
    }
}
