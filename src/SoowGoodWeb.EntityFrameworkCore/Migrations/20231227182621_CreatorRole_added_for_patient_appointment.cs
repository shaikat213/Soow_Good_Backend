using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreatorRole_added_for_patient_appointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CratorCode",
                table: "SgPatientProfiles",
                newName: "CreatorRole");

            migrationBuilder.AddColumn<string>(
                name: "CreatorCode",
                table: "SgPatientProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AppointmentCreatorCode",
                table: "SgAppointments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AppointmentCreatorRole",
                table: "SgAppointments",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorCode",
                table: "SgPatientProfiles");

            migrationBuilder.DropColumn(
                name: "AppointmentCreatorCode",
                table: "SgAppointments");

            migrationBuilder.DropColumn(
                name: "AppointmentCreatorRole",
                table: "SgAppointments");

            migrationBuilder.RenameColumn(
                name: "CreatorRole",
                table: "SgPatientProfiles",
                newName: "CratorCode");
        }
    }
}
