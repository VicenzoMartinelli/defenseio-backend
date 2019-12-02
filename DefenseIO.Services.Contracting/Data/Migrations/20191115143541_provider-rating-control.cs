using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Contracting.Data.Migrations
{
    public partial class providerratingcontrol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("43c7012c-cf01-4f17-9199-01c9fccee2d1"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("5ff00d73-33a9-46c3-90e3-41c33f8f24d6"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("d22000ff-0fc3-41b3-87ca-cdfe67c980b6"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("d661d544-f841-4635-90df-f605d7bfaea2"));

            migrationBuilder.AddColumn<double>(
                name: "CurrentRating",
                table: "ContractingUser",
                nullable: false,
                defaultValue: 3.0);

            migrationBuilder.InsertData(
                table: "Modality",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("53468f99-518e-45b3-8a41-4e4343be8299"), "Segurança pessoal", "Personal" },
                    { new Guid("fea53619-b1d7-4c96-b900-af9b7e259067"), "Escolta armada", "ArmedEscort" },
                    { new Guid("c445e5d5-f924-4b0a-a9b6-b4ba1f0761e9"), "Transporte de valores", "ValuesTransportation" },
                    { new Guid("d5c65e35-71af-4153-af8a-822d8ae658d8"), "Segurança patrimonial", "AssetSurveillance" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("53468f99-518e-45b3-8a41-4e4343be8299"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("c445e5d5-f924-4b0a-a9b6-b4ba1f0761e9"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("d5c65e35-71af-4153-af8a-822d8ae658d8"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("fea53619-b1d7-4c96-b900-af9b7e259067"));

            migrationBuilder.DropColumn(
                name: "CurrentRating",
                table: "ContractingUser");

            migrationBuilder.InsertData(
                table: "Modality",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("5ff00d73-33a9-46c3-90e3-41c33f8f24d6"), "Segurança pessoal", "Personal" },
                    { new Guid("43c7012c-cf01-4f17-9199-01c9fccee2d1"), "Escolta armada", "ArmedEscort" },
                    { new Guid("d22000ff-0fc3-41b3-87ca-cdfe67c980b6"), "Transporte de valores", "ValuesTransportation" },
                    { new Guid("d661d544-f841-4635-90df-f605d7bfaea2"), "Segurança patrimonial", "AssetSurveillance" }
                });
        }
    }
}
