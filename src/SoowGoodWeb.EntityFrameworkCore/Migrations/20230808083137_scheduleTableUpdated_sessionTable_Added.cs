using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class scheduleTableUpdated_sessionTable_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "SgDoctorSchedules");

            migrationBuilder.DropColumn(
                name: "NoOfPatients",
                table: "SgDoctorSchedules");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "SgDoctorSchedules");

            migrationBuilder.CreateTable(
                name: "DoctorScheduleDaySessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    ScheduleDayofWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DoctorScheduleDaySessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorScheduleDaySessions_SgDoctorSchedules_DoctorScheduleId",
                        column: x => x.DoctorScheduleId,
                        principalTable: "SgDoctorSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorScheduleDaySessions_DoctorScheduleId",
                table: "DoctorScheduleDaySessions",
                column: "DoctorScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorScheduleDaySessions");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "SgDoctorSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfPatients",
                table: "SgDoctorSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "SgDoctorSchedules",
                type: "datetime2",
                nullable: true);
        }
    }
}
