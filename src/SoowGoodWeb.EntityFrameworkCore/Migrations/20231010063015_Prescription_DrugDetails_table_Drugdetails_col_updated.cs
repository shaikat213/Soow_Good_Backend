using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class Prescription_DrugDetails_table_Drugdetails_col_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrugDoseTiming",
                table: "SgPrescriptionDrugDetails",
                newName: "DrugDoseScheduleDays");

            migrationBuilder.RenameColumn(
                name: "DrugDoseDays",
                table: "SgPrescriptionDrugDetails",
                newName: "DrugDoseSchedule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrugDoseScheduleDays",
                table: "SgPrescriptionDrugDetails",
                newName: "DrugDoseTiming");

            migrationBuilder.RenameColumn(
                name: "DrugDoseSchedule",
                table: "SgPrescriptionDrugDetails",
                newName: "DrugDoseDays");
        }
    }
}
