using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Contracting.Data.Migrations
{
    public partial class addseedsmodality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modality",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("4b8b3ed4-ccb5-4322-8cd6-350961f62351"), "Segurança pessoal", "Personal" },
                    { new Guid("149999ef-e145-4df4-a712-8820674a3184"), "Escolta armada", "ArmedEscort" },
                    { new Guid("3a515d77-5947-4884-bc8a-16e6f2674c82"), "Transporte de valores", "ValuesTransportation" },
                    { new Guid("03bcf91a-896b-4bdf-a819-e9db394780e0"), "Segurança patrimonial", "AssetSurveillance" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("03bcf91a-896b-4bdf-a819-e9db394780e0"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("149999ef-e145-4df4-a712-8820674a3184"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("3a515d77-5947-4884-bc8a-16e6f2674c82"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("4b8b3ed4-ccb5-4322-8cd6-350961f62351"));
        }
    }
}
