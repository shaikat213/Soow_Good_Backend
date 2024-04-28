using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class App_Code_Doctor_Code_Patent_Codeadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientCode",
                table: "SgPatientProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppointmenCode",
                table: "SgAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorCode",
                table: "SgAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientCode",
                table: "SgAppointments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientCode",
                table: "SgPatientProfiles");

            migrationBuilder.DropColumn(
                name: "AppointmenCode",
                table: "SgAppointments");

            migrationBuilder.DropColumn(
                name: "DoctorCode",
                table: "SgAppointments");

            migrationBuilder.DropColumn(
                name: "PatientCode",
                table: "SgAppointments");
        }
    }
}
