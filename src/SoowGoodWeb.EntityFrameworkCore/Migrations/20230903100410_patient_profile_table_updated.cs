using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class patient_profile_table_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatorEntityId",
                table: "SgPatientProfiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientEmail",
                table: "SgPatientProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientMobileNo",
                table: "SgPatientProfiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorEntityId",
                table: "SgPatientProfiles");

            migrationBuilder.DropColumn(
                name: "PatientEmail",
                table: "SgPatientProfiles");

            migrationBuilder.DropColumn(
                name: "PatientMobileNo",
                table: "SgPatientProfiles");
        }
    }
}
