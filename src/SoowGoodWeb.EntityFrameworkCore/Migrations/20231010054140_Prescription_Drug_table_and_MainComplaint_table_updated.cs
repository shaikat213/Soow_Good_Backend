using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class Prescription_Drug_table_and_MainComplaint_table_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dose",
                table: "SgPrescriptionDrugDetails",
                newName: "timingDays");

            migrationBuilder.AddColumn<string>(
                name: "Symptom",
                table: "SgPrescriptionMainComplaints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoseTiming",
                table: "SgPrescriptionDrugDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDrugExceptional",
                table: "SgPrescriptionDrugDetails",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symptom",
                table: "SgPrescriptionMainComplaints");

            migrationBuilder.DropColumn(
                name: "DoseTiming",
                table: "SgPrescriptionDrugDetails");

            migrationBuilder.DropColumn(
                name: "IsDrugExceptional",
                table: "SgPrescriptionDrugDetails");

            migrationBuilder.RenameColumn(
                name: "timingDays",
                table: "SgPrescriptionDrugDetails",
                newName: "Dose");
        }
    }
}
