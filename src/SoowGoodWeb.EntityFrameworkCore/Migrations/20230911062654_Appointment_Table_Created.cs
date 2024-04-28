using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class Appointment_Table_Created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SgAppointments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorProfileId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientProfileId = table.Column<long>(type: "bigint", nullable: true),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultancyType = table.Column<int>(type: "int", nullable: true),
                    DoctorChamberId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorScheduleDaySessionId = table.Column<long>(type: "bigint", nullable: true),
                    ScheduleDayofWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentType = table.Column<int>(type: "int", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorFeesSetupId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AgentFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlatformFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAppointmentFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AppointmentStatus = table.Column<int>(type: "int", nullable: true),
                    AppointmentPaymentStatus = table.Column<int>(type: "int", nullable: true),
                    CancelledByEntityId = table.Column<long>(type: "bigint", nullable: true),
                    CancelledByRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SgAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgAppointments_SgDoctorSchedules_DoctorScheduleId",
                        column: x => x.DoctorScheduleId,
                        principalTable: "SgDoctorSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SgAppointments_DoctorScheduleId",
                table: "SgAppointments",
                column: "DoctorScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SgAppointments");
        }
    }
}
