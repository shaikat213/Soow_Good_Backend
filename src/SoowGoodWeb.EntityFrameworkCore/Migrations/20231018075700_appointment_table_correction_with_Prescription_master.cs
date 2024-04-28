using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class appointment_table_correction_with_Prescription_master : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentCode",
                table: "SgPrescriptionMaster",
                newName: "AppointmenCode");

            migrationBuilder.RenameColumn(
                name: "AppointmenCode",
                table: "SgAppointments",
                newName: "AppointmentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmenCode",
                table: "SgPrescriptionMaster",
                newName: "AppointmentCode");

            migrationBuilder.RenameColumn(
                name: "AppointmentCode",
                table: "SgAppointments",
                newName: "AppointmenCode");
        }
    }
}
