using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DefenseIO.Services.Chat.Data.Migrations
{
  public partial class addedfiedsmessages : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "DestinationUserName",
          table: "ChatMessage",
          nullable: true);

      migrationBuilder.AddColumn<DateTime>(
          name: "SendedAt",
          table: "ChatMessage",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "DestinationUserName",
          table: "ChatMessage");

      migrationBuilder.DropColumn(
          name: "SendedAt",
          table: "ChatMessage");
    }
  }
}
