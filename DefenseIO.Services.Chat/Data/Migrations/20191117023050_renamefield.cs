using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Chat.Data.Migrations
{
    public partial class renamefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DestinationUserName",
                table: "ChatMessage",
                newName: "SenderName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "ChatMessage",
                newName: "DestinationUserName");
        }
    }
}
