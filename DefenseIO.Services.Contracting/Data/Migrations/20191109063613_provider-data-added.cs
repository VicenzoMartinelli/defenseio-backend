using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Contracting.Data.Migrations
{
    public partial class providerdataadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Location_Complement",
                table: "Solicitation",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_Cep",
                table: "Solicitation",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Location_Burgh",
                table: "Solicitation",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Location_AddressNumber",
                table: "Solicitation",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_Address",
                table: "Solicitation",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDateTime",
                table: "Solicitation",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    BrazilianInscricaoEstadual = table.Column<string>(maxLength: 15, nullable: true),
                    LicenseValidity = table.Column<DateTime>(nullable: false),
                    User_Id = table.Column<Guid>(nullable: false),
                    User_UserName = table.Column<string>(nullable: true),
                    User_NormalizedUserName = table.Column<string>(nullable: true),
                    User_Email = table.Column<string>(nullable: true),
                    User_NormalizedEmail = table.Column<string>(nullable: true),
                    User_EmailConfirmed = table.Column<bool>(nullable: false),
                    User_PasswordHash = table.Column<string>(nullable: true),
                    User_SecurityStamp = table.Column<string>(nullable: true),
                    User_ConcurrencyStamp = table.Column<string>(nullable: true),
                    User_PhoneNumber = table.Column<string>(nullable: true),
                    User_PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    User_TwoFactorEnabled = table.Column<bool>(nullable: false),
                    User_LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    User_LockoutEnabled = table.Column<bool>(nullable: false),
                    User_AccessFailedCount = table.Column<int>(nullable: false),
                    User_Name = table.Column<string>(maxLength: 160, nullable: true),
                    User_Active = table.Column<bool>(nullable: false, defaultValue: true),
                    User_PrimaryLocation_Longitude = table.Column<double>(nullable: false),
                    User_PrimaryLocation_Latitude = table.Column<double>(nullable: false),
                    User_PrimaryLocation_Cep = table.Column<string>(maxLength: 15, nullable: false),
                    User_PrimaryLocation_Address = table.Column<string>(maxLength: 80, nullable: false),
                    User_PrimaryLocation_AddressNumber = table.Column<string>(maxLength: 8, nullable: true),
                    User_PrimaryLocation_Complement = table.Column<string>(maxLength: 60, nullable: true),
                    User_PrimaryLocation_Burgh = table.Column<string>(maxLength: 80, nullable: false),
                    User_PrimaryLocation_CityId = table.Column<Guid>(nullable: false),
                    User_LastPasswordReset = table.Column<DateTime>(nullable: true),
                    User_Type = table.Column<int>(nullable: false),
                    User_DocumentIdentifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Modality",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("f13f8e2f-0b7d-4d15-8621-fa8a4c9758bf"), "Segurança pessoal", "Personal" },
                    { new Guid("d42f34c2-e175-41bb-87f2-4b71cf08f009"), "Escolta armada", "ArmedEscort" },
                    { new Guid("1d2bed80-f20c-495d-8aec-ab7901a7caaa"), "Transporte de valores", "ValuesTransportation" },
                    { new Guid("3c55bd7e-6e8d-490c-aa43-7ad891661482"), "Segurança patrimonial", "AssetSurveillance" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("1d2bed80-f20c-495d-8aec-ab7901a7caaa"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("3c55bd7e-6e8d-490c-aa43-7ad891661482"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("d42f34c2-e175-41bb-87f2-4b71cf08f009"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("f13f8e2f-0b7d-4d15-8621-fa8a4c9758bf"));

            migrationBuilder.AlterColumn<string>(
                name: "Location_Complement",
                table: "Solicitation",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_Cep",
                table: "Solicitation",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_Burgh",
                table: "Solicitation",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_AddressNumber",
                table: "Solicitation",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_Address",
                table: "Solicitation",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDateTime",
                table: "Solicitation",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

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
    }
}
