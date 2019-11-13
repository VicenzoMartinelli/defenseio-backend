using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Contracting.Data.Migrations
{
    public partial class removedcityproviderfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("d25f6b84-1ca1-412d-b388-b568666b5097"), "Segurança pessoal", "Personal" },
                    { new Guid("79234807-aa1b-4962-b3d3-d4185f8f24dd"), "Escolta armada", "ArmedEscort" },
                    { new Guid("e9e92c7e-d91f-4fd2-83a5-b7979084e9c5"), "Transporte de valores", "ValuesTransportation" },
                    { new Guid("0b783988-a1a3-4eb0-b434-84f6e41b6212"), "Segurança patrimonial", "AssetSurveillance" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Initials = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                    DistrictId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
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
    }
}
