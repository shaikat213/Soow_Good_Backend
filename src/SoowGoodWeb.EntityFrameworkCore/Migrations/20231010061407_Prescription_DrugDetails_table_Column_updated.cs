using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class Prescription_DrugDetails_table_Column_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoseTimingDays",
                table: "SgPrescriptionDrugDetails",
                newName: "DrugDoseTimingDays");

            migrationBuilder.RenameColumn(
                name: "DoseTiming",
                table: "SgPrescriptionDrugDetails",
                newName: "DrugDoseTiming");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrugDoseTimingDays",
                table: "SgPrescriptionDrugDetails",
                newName: "DoseTimingDays");

            migrationBuilder.RenameColumn(
                name: "DrugDoseTiming",
                table: "SgPrescriptionDrugDetails",
                newName: "DoseTiming");
        }
    }
}
