using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kennel_bambino.web.Data.Migrations
{
    public partial class AddContactDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: false),
                    Title = table.Column<string>(maxLength: 120, nullable: false),
                    Description = table.Column<string>(maxLength: 750, nullable: false),
                    IsChecked = table.Column<bool>(nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
