using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenseIO.Services.Contracting.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modality",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendedModality",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Method = table.Column<string>(nullable: false),
                    BasicValue = table.Column<double>(nullable: false),
                    MultiplyByEmployeesNumber = table.Column<bool>(nullable: false, defaultValue: false),
                    ProviderUserId = table.Column<Guid>(nullable: false),
                    ModalityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendedModality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendedModality_Modality_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ModalityType = table.Column<int>(nullable: false),
                    SolicitationDate = table.Column<DateTime>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    TurnStart = table.Column<TimeSpan>(nullable: true),
                    TurnOver = table.Column<TimeSpan>(nullable: true),
                    Location_Longitude = table.Column<double>(nullable: false),
                    Location_Latitude = table.Column<double>(nullable: false),
                    Location_Cep = table.Column<string>(maxLength: 15, nullable: false),
                    Location_Address = table.Column<string>(maxLength: 80, nullable: false),
                    Location_AddressNumber = table.Column<string>(maxLength: 8, nullable: true),
                    Location_Complement = table.Column<string>(maxLength: 60, nullable: true),
                    Location_Burgh = table.Column<string>(maxLength: 80, nullable: false),
                    Location_CityId = table.Column<Guid>(nullable: false),
                    Remark = table.Column<string>(maxLength: 1000, nullable: true),
                    NumberOfEmployeers = table.Column<int>(nullable: true),
                    KiloMeters = table.Column<double>(nullable: true),
                    FinalCost = table.Column<double>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    AttendedModalityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitation_AttendedModality_AttendedModalityId",
                        column: x => x.AttendedModalityId,
                        principalTable: "AttendedModality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitationEvaluation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EvaluationDate = table.Column<DateTime>(nullable: false),
                    SpeedGrade = table.Column<double>(nullable: false),
                    EfficiencyGrade = table.Column<double>(nullable: false),
                    ExperienceGrade = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true),
                    SolicitationId = table.Column<Guid>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitationEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitationEvaluation_Solicitation_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendedModality_ModalityId",
                table: "AttendedModality",
                column: "ModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendedModality_ProviderUserId",
                table: "AttendedModality",
                column: "ProviderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitation_AttendedModalityId",
                table: "Solicitation",
                column: "AttendedModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationEvaluation_SolicitationId",
                table: "SolicitationEvaluation",
                column: "SolicitationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitationEvaluation");

            migrationBuilder.DropTable(
                name: "Solicitation");

            migrationBuilder.DropTable(
                name: "AttendedModality");

            migrationBuilder.DropTable(
                name: "Modality");
        }
    }
}
