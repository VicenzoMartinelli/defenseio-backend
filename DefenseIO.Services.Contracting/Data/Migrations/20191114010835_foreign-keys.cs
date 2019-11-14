using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Contracting.Data.Migrations
{
    public partial class foreignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_ClientId",
                table: "Solicitation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_ProviderId",
                table: "Solicitation",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitation_ContractingUser_ClientId",
                table: "Solicitation",
                column: "ClientId",
                principalTable: "ContractingUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitation_ContractingUser_ProviderId",
                table: "Solicitation",
                column: "ProviderId",
                principalTable: "ContractingUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitation_ContractingUser_ClientId",
                table: "Solicitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitation_ContractingUser_ProviderId",
                table: "Solicitation");

            migrationBuilder.DropIndex(
                name: "IX_Solicitation_ClientId",
                table: "Solicitation");

            migrationBuilder.DropIndex(
                name: "IX_Solicitation_ProviderId",
                table: "Solicitation");

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
    }
}
