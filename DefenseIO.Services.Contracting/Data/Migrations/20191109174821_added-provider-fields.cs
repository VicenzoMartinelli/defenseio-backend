using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Contracting.Data.Migrations
{
    public partial class addedproviderfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DistrictId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modality",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("0dfb8c92-3bf7-4d13-aaf5-f9ced88a1ada"), "Segurança pessoal", "Personal" },
                    { new Guid("5efd700b-97a2-47f2-aa9c-cbc025b474bc"), "Escolta armada", "ArmedEscort" },
                    { new Guid("28be71dc-0c2c-4421-b796-41a47ca2726e"), "Transporte de valores", "ValuesTransportation" },
                    { new Guid("ff29aaca-5574-499b-8d47-883c8f4883cf"), "Segurança patrimonial", "AssetSurveillance" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_Location_CityId",
                table: "Solicitation",
                column: "Location_CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_User_PrimaryLocation_CityId",
                table: "Provider",
                column: "User_PrimaryLocation_CityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_DistrictId",
                table: "City",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_City_User_PrimaryLocation_CityId",
                table: "Provider",
                column: "User_PrimaryLocation_CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitation_City_Location_CityId",
                table: "Solicitation",
                column: "Location_CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provider_City_User_PrimaryLocation_CityId",
                table: "Provider");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitation_City_Location_CityId",
                table: "Solicitation");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropIndex(
                name: "IX_Solicitation_Location_CityId",
                table: "Solicitation");

            migrationBuilder.DropIndex(
                name: "IX_Provider_User_PrimaryLocation_CityId",
                table: "Provider");

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("0dfb8c92-3bf7-4d13-aaf5-f9ced88a1ada"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("28be71dc-0c2c-4421-b796-41a47ca2726e"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("5efd700b-97a2-47f2-aa9c-cbc025b474bc"));

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "Id",
                keyValue: new Guid("ff29aaca-5574-499b-8d47-883c8f4883cf"));

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
    }
}
