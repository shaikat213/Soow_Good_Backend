using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class Doctor_Schedules_Fees_TablesCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassingYear",
                table: "SgDoctorDegrees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SgDoctorSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorProfileId = table.Column<long>(type: "bigint", nullable: true),
                    ScheduleType = table.Column<int>(type: "int", nullable: true),
                    ConsultancyType = table.Column<int>(type: "int", nullable: true),
                    ChamberId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorChamberId = table.Column<long>(type: "bigint", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoOfPatients = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_SgDoctorSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDoctorSchedules_SgDoctorChambers_DoctorChamberId",
                        column: x => x.DoctorChamberId,
                        principalTable: "SgDoctorChambers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SgDoctorSchedules_SgDoctorProfiles_DoctorProfileId",
                        column: x => x.DoctorProfileId,
                        principalTable: "SgDoctorProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgDoctorFees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    AppointmentType = table.Column<int>(type: "int", nullable: true),
                    CurrentFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PreviousFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FeeAppliedFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FollowUpPeriod = table.Column<int>(type: "int", nullable: true),
                    ReportShowPeriod = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountAppliedFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescountPeriod = table.Column<int>(type: "int", nullable: true),
                    TotalFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_SgDoctorFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDoctorFees_SgDoctorSchedules_DoctorScheduleId",
                        column: x => x.DoctorScheduleId,
                        principalTable: "SgDoctorSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgDoctorScheduledDayOffs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    OffDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_SgDoctorScheduledDayOffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDoctorScheduledDayOffs_SgDoctorSchedules_DoctorScheduleId",
                        column: x => x.DoctorScheduleId,
                        principalTable: "SgDoctorSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorFees_DoctorScheduleId",
                table: "SgDoctorFees",
                column: "DoctorScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorScheduledDayOffs_DoctorScheduleId",
                table: "SgDoctorScheduledDayOffs",
                column: "DoctorScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorSchedules_DoctorChamberId",
                table: "SgDoctorSchedules",
                column: "DoctorChamberId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorSchedules_DoctorProfileId",
                table: "SgDoctorSchedules",
                column: "DoctorProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SgDoctorFees");

            migrationBuilder.DropTable(
                name: "SgDoctorScheduledDayOffs");

            migrationBuilder.DropTable(
                name: "SgDoctorSchedules");

            migrationBuilder.DropColumn(
                name: "PassingYear",
                table: "SgDoctorDegrees");
        }
    }
}
