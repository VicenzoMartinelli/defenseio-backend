using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Contracting.Data.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("47ea2033-b73e-487d-9ba1-3a9398e620d8"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("638d1bec-049d-462c-aeb6-313044ba95a6"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("66d338a1-3040-4aae-b4a4-6405374c2e39"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("96c43078-5b52-4f75-94aa-4ef8d07c3b03"));

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "ContractingUser",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "Modality",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("8f3f5c3d-bceb-4c40-8846-a110f1fa59e4"), "Segurança pessoal", "Personal" },
                    { new Guid("f3ed50b1-eec4-4080-906a-0ade4bce1d2f"), "Escolta armada", "ArmedEscort" },
                    { new Guid("60ade3c6-ba63-4529-b142-c69bc1d0ca66"), "Transporte de valores", "ValuesTransportation" },
                    { new Guid("d6f2e310-3937-4d09-b8f3-b0fe800981e5"), "Segurança patrimonial", "AssetSurveillance" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("60ade3c6-ba63-4529-b142-c69bc1d0ca66"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("8f3f5c3d-bceb-4c40-8846-a110f1fa59e4"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("d6f2e310-3937-4d09-b8f3-b0fe800981e5"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("f3ed50b1-eec4-4080-906a-0ade4bce1d2f"));

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "ContractingUser",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Modality",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("47ea2033-b73e-487d-9ba1-3a9398e620d8"), "Segurança pessoal", "Personal" },
                    { new Guid("66d338a1-3040-4aae-b4a4-6405374c2e39"), "Escolta armada", "ArmedEscort" },
                    { new Guid("638d1bec-049d-462c-aeb6-313044ba95a6"), "Transporte de valores", "ValuesTransportation" },
                    { new Guid("96c43078-5b52-4f75-94aa-4ef8d07c3b03"), "Segurança patrimonial", "AssetSurveillance" }
                });
        }
    }
}
