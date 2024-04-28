using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class Prescription_DrugDetails_table_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "timingDays",
                table: "SgPrescriptionDrugDetails",
                newName: "DoseTimingDays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoseTimingDays",
                table: "SgPrescriptionDrugDetails",
                newName: "timingDays");
        }
    }
}
