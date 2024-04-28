using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class AllDrugsAndPrescriptonDatabase_create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SgCommonDiseases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SgCommonDiseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SgDrugRx",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenericName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosageForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InclusionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VlidUpto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CDAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GDAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SgDrugRx", x => x.Id);
                });

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
                    ConsultancyType = table.Column<int>(type: "int", nullable: true),
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
                name: "SgPrescriptionDrugDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionMasterId = table.Column<long>(type: "bigint", nullable: true),
                    DrugRxId = table.Column<long>(type: "bigint", nullable: true),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugDoseSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDrugExceptional = table.Column<bool>(type: "bit", nullable: true),
                    DrugDoseScheduleDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SgPrescriptionDrugDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgPrescriptionDrugDetails_SgDrugRx_DrugRxId",
                        column: x => x.DrugRxId,
                        principalTable: "SgDrugRx",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SgPrescriptionDrugDetails_SgPrescriptionMaster_PrescriptionMasterId",
                        column: x => x.PrescriptionMasterId,
                        principalTable: "SgPrescriptionMaster",
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
                    Symptom = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "IX_SgPrescriptionDrugDetails_DrugRxId",
                table: "SgPrescriptionDrugDetails",
                column: "DrugRxId");

            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionDrugDetails_PrescriptionMasterId",
                table: "SgPrescriptionDrugDetails",
                column: "PrescriptionMasterId");

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
                name: "SgPrescriptionDrugDetails");

            migrationBuilder.DropTable(
                name: "SgPrescriptionFindingsObservations");

            migrationBuilder.DropTable(
                name: "SgPrescriptionMainComplaints");

            migrationBuilder.DropTable(
                name: "SgPrescriptionMedicalCheckups");

            migrationBuilder.DropTable(
                name: "SgPrescriptionPatientDiseaseHistory");

            migrationBuilder.DropTable(
                name: "SgDrugRx");

            migrationBuilder.DropTable(
                name: "SgCommonDiseases");

            migrationBuilder.DropTable(
                name: "SgPrescriptionMaster");
        }
    }
}
