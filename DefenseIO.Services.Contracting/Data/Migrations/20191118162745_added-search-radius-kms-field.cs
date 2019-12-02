using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Contracting.Data.Migrations
{
    public partial class addedsearchradiuskmsfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<long>(
                name: "KiloMetersSearchRadius",
                table: "ContractingUser",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "Modality",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("afc5a754-2937-4065-9f9f-dfc728e2fa01"), "Segurança pessoal", "Personal" },
                    { new Guid("824f7009-3dab-46a0-8973-7b9ed0910415"), "Escolta armada", "ArmedEscort" },
                    { new Guid("bda557f0-57b6-45ab-ad15-f1e4431b683f"), "Transporte de valores", "ValuesTransportation" },
                    { new Guid("954f2748-dd6c-450f-878c-3eb9cd62615b"), "Segurança patrimonial", "AssetSurveillance" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("824f7009-3dab-46a0-8973-7b9ed0910415"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("954f2748-dd6c-450f-878c-3eb9cd62615b"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("afc5a754-2937-4065-9f9f-dfc728e2fa01"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("bda557f0-57b6-45ab-ad15-f1e4431b683f"));

            migrationBuilder.DropColumn(
                name: "KiloMetersSearchRadius",
                table: "ContractingUser");

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
    }
}
