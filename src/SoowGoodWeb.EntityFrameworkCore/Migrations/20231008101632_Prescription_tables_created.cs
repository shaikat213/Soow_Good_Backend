using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class Prescription_tables_created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommonDisease_SgPatientProfiles_PatientProfileId",
                table: "CommonDisease");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommonDisease",
                table: "CommonDisease");

            migrationBuilder.DropIndex(
                name: "IX_CommonDisease_PatientProfileId",
                table: "CommonDisease");

            migrationBuilder.DropColumn(
                name: "LifeStyle",
                table: "SgPatientProfiles");

            migrationBuilder.DropColumn(
                name: "PatientProfileId",
                table: "CommonDisease");

            migrationBuilder.RenameTable(
                name: "CommonDisease",
                newName: "SgCommonDiseases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SgCommonDiseases",
                table: "SgCommonDiseases",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SgPrescriptionMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefferenceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentId = table.Column<long>(type: "bigint", nullable: true),
                    AppointmentSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorProfileId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientProfileId = table.Column<long>(type: "bigint", nullable: true),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultancyType = table.Column<int>(type: "int", nullable: false),
                    AppointmentType = table.Column<int>(type: "int", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrescriptionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PatientLifeStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportShowDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FollowupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Advice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SgPrescriptionMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgPrescriptionMaster_SgAppointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "SgAppointments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgPrescriptionFindingsObservations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionMasterId = table.Column<long>(type: "bigint", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SgPrescriptionFindingsObservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgPrescriptionFindingsObservations_SgPrescriptionMaster_PrescriptionMasterId",
                        column: x => x.PrescriptionMasterId,
                        principalTable: "SgPrescriptionMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgPrescriptionMainComplaints",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionMasterId = table.Column<long>(type: "bigint", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Problems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicianRecommendedAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SgPrescriptionMainComplaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgPrescriptionMainComplaints_SgPrescriptionMaster_PrescriptionMasterId",
                        column: x => x.PrescriptionMasterId,
                        principalTable: "SgPrescriptionMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgPrescriptionMedicalCheckups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionMasterId = table.Column<long>(type: "bigint", nullable: true),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SgPrescriptionMedicalCheckups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgPrescriptionMedicalCheckups_SgPrescriptionMaster_PrescriptionMasterId",
                        column: x => x.PrescriptionMasterId,
                        principalTable: "SgPrescriptionMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgPrescriptionPatientDiseaseHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionMasterId = table.Column<long>(type: "bigint", nullable: true),
                    PatientProfileId = table.Column<long>(type: "bigint", nullable: true),
                    CommonDiseaseId = table.Column<long>(type: "bigint", nullable: true),
                    DiseaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SgPrescriptionPatientDiseaseHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgPrescriptionPatientDiseaseHistory_SgCommonDiseases_CommonDiseaseId",
                        column: x => x.CommonDiseaseId,
                        principalTable: "SgCommonDiseases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SgPrescriptionPatientDiseaseHistory_SgPrescriptionMaster_PrescriptionMasterId",
                        column: x => x.PrescriptionMasterId,
                        principalTable: "SgPrescriptionMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionFindingsObservations_PrescriptionMasterId",
                table: "SgPrescriptionFindingsObservations",
                column: "PrescriptionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionMainComplaints_PrescriptionMasterId",
                table: "SgPrescriptionMainComplaints",
                column: "PrescriptionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionMaster_AppointmentId",
                table: "SgPrescriptionMaster",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionMedicalCheckups_PrescriptionMasterId",
                table: "SgPrescriptionMedicalCheckups",
                column: "PrescriptionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionPatientDiseaseHistory_CommonDiseaseId",
                table: "SgPrescriptionPatientDiseaseHistory",
                column: "CommonDiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionPatientDiseaseHistory_PrescriptionMasterId",
                table: "SgPrescriptionPatientDiseaseHistory",
                column: "PrescriptionMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SgPrescriptionFindingsObservations");

            migrationBuilder.DropTable(
                name: "SgPrescriptionMainComplaints");

            migrationBuilder.DropTable(
                name: "SgPrescriptionMedicalCheckups");

            migrationBuilder.DropTable(
                name: "SgPrescriptionPatientDiseaseHistory");

            migrationBuilder.DropTable(
                name: "SgPrescriptionMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SgCommonDiseases",
                table: "SgCommonDiseases");

            migrationBuilder.RenameTable(
                name: "SgCommonDiseases",
                newName: "CommonDisease");

            migrationBuilder.AddColumn<string>(
                name: "LifeStyle",
                table: "SgPatientProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PatientProfileId",
                table: "CommonDisease",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommonDisease",
                table: "CommonDisease",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommonDisease_PatientProfileId",
                table: "CommonDisease",
                column: "PatientProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommonDisease_SgPatientProfiles_PatientProfileId",
                table: "CommonDisease",
                column: "PatientProfileId",
                principalTable: "SgPatientProfiles",
                principalColumn: "Id");
        }
    }
}
