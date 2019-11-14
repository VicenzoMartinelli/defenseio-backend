using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Contracting.Data.Migrations
{
    public partial class addeduserreplicatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("0b783988-a1a3-4eb0-b434-84f6e41b6212"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("79234807-aa1b-4962-b3d3-d4185f8f24dd"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("d25f6b84-1ca1-412d-b388-b568666b5097"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("e9e92c7e-d91f-4fd2-83a5-b7979084e9c5"));

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

            migrationBuilder.CreateTable(
                name: "ContractingUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 160, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    DocumentIdentifier = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Cep = table.Column<string>(maxLength: 15, nullable: false),
                    Address = table.Column<string>(maxLength: 80, nullable: false),
                    AddressNumber = table.Column<string>(maxLength: 8, nullable: true),
                    Complement = table.Column<string>(maxLength: 60, nullable: true),
                    Burgh = table.Column<string>(maxLength: 80, nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    BrazilianInscricaoEstadual = table.Column<string>(maxLength: 15, nullable: true),
                    LicenseValidity = table.Column<DateTime>(nullable: false),
                    Rg = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractingUser", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_AttendedModality_ContractingUser_ProviderUserId",
                table: "AttendedModality",
                column: "ProviderUserId",
                principalTable: "ContractingUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendedModality_ContractingUser_ProviderUserId",
                table: "AttendedModality");

            migrationBuilder.DropTable(
                name: "ContractingUser");

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

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    BrazilianInscricaoEstadual = table.Column<string>(maxLength: 15, nullable: true),
                    LicenseValidity = table.Column<DateTime>(nullable: false),
                    User_AccessFailedCount = table.Column<int>(nullable: false),
                    User_Active = table.Column<bool>(nullable: false, defaultValue: true),
                    User_ConcurrencyStamp = table.Column<string>(nullable: true),
                    User_DocumentIdentifier = table.Column<string>(nullable: true),
                    User_Email = table.Column<string>(nullable: true),
                    User_EmailConfirmed = table.Column<bool>(nullable: false),
                    User_Id = table.Column<Guid>(nullable: false),
                    User_LastPasswordReset = table.Column<DateTime>(nullable: true),
                    User_LockoutEnabled = table.Column<bool>(nullable: false),
                    User_LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    User_Name = table.Column<string>(maxLength: 160, nullable: true),
                    User_NormalizedEmail = table.Column<string>(nullable: true),
                    User_NormalizedUserName = table.Column<string>(nullable: true),
                    User_PasswordHash = table.Column<string>(nullable: true),
                    User_PhoneNumber = table.Column<string>(nullable: true),
                    User_PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    User_SecurityStamp = table.Column<string>(nullable: true),
                    User_TwoFactorEnabled = table.Column<bool>(nullable: false),
                    User_Type = table.Column<int>(nullable: false),
                    User_UserName = table.Column<string>(nullable: true),
                    User_PrimaryLocation_Address = table.Column<string>(maxLength: 80, nullable: false),
                    User_PrimaryLocation_AddressNumber = table.Column<string>(maxLength: 8, nullable: true),
                    User_PrimaryLocation_Burgh = table.Column<string>(maxLength: 80, nullable: false),
                    User_PrimaryLocation_Cep = table.Column<string>(maxLength: 15, nullable: false),
                    User_PrimaryLocation_CityId = table.Column<Guid>(nullable: false),
                    User_PrimaryLocation_Complement = table.Column<string>(maxLength: 60, nullable: true),
                    User_PrimaryLocation_Latitude = table.Column<double>(nullable: false),
                    User_PrimaryLocation_Longitude = table.Column<double>(nullable: false)
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
                    { new Guid("d25f6b84-1ca1-412d-b388-b568666b5097"), "Segurança pessoal", "Personal" },
                    { new Guid("79234807-aa1b-4962-b3d3-d4185f8f24dd"), "Escolta armada", "ArmedEscort" },
                    { new Guid("e9e92c7e-d91f-4fd2-83a5-b7979084e9c5"), "Transporte de valores", "ValuesTransportation" },
                    { new Guid("0b783988-a1a3-4eb0-b434-84f6e41b6212"), "Segurança patrimonial", "AssetSurveillance" }
                });
        }
    }
}
