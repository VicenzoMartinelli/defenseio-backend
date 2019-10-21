using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Geographic.Migrations
{
    public partial class addedinitialsdistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Initials",
                table: "District",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Initials",
                table: "District");
        }
    }
}
