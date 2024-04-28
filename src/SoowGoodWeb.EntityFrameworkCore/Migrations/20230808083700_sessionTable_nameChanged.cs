using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class sessionTable_nameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorScheduleDaySessions_SgDoctorSchedules_DoctorScheduleId",
                table: "DoctorScheduleDaySessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorScheduleDaySessions",
                table: "DoctorScheduleDaySessions");

            migrationBuilder.RenameTable(
                name: "DoctorScheduleDaySessions",
                newName: "SgDoctorScheduleDaySessions");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorScheduleDaySessions_DoctorScheduleId",
                table: "SgDoctorScheduleDaySessions",
                newName: "IX_SgDoctorScheduleDaySessions_DoctorScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SgDoctorScheduleDaySessions",
                table: "SgDoctorScheduleDaySessions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorScheduleDaySessions_SgDoctorSchedules_DoctorScheduleId",
                table: "SgDoctorScheduleDaySessions",
                column: "DoctorScheduleId",
                principalTable: "SgDoctorSchedules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorScheduleDaySessions_SgDoctorSchedules_DoctorScheduleId",
                table: "SgDoctorScheduleDaySessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SgDoctorScheduleDaySessions",
                table: "SgDoctorScheduleDaySessions");

            migrationBuilder.RenameTable(
                name: "SgDoctorScheduleDaySessions",
                newName: "DoctorScheduleDaySessions");

            migrationBuilder.RenameIndex(
                name: "IX_SgDoctorScheduleDaySessions_DoctorScheduleId",
                table: "DoctorScheduleDaySessions",
                newName: "IX_DoctorScheduleDaySessions_DoctorScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorScheduleDaySessions",
                table: "DoctorScheduleDaySessions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorScheduleDaySessions_SgDoctorSchedules_DoctorScheduleId",
                table: "DoctorScheduleDaySessions",
                column: "DoctorScheduleId",
                principalTable: "SgDoctorSchedules",
                principalColumn: "Id");
        }
    }
}
