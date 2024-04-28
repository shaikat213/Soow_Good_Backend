using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class Prescription_DrugDetails_table_DrugDays_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrugDoseTimingDays",
                table: "SgPrescriptionDrugDetails",
                newName: "DrugDoseDays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrugDoseDays",
                table: "SgPrescriptionDrugDetails",
                newName: "DrugDoseTimingDays");
        }
    }
}
