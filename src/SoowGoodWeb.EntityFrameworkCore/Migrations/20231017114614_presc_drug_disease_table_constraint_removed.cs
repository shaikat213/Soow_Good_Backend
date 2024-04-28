using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class presc_drug_disease_table_constraint_removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SgPrescriptionDrugDetails_SgDrugRx_DrugRxId",
                table: "SgPrescriptionDrugDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SgPrescriptionPatientDiseaseHistory_SgCommonDiseases_CommonDiseaseId",
                table: "SgPrescriptionPatientDiseaseHistory");

            migrationBuilder.DropIndex(
                name: "IX_SgPrescriptionPatientDiseaseHistory_CommonDiseaseId",
                table: "SgPrescriptionPatientDiseaseHistory");

            migrationBuilder.DropIndex(
                name: "IX_SgPrescriptionDrugDetails_DrugRxId",
                table: "SgPrescriptionDrugDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionPatientDiseaseHistory_CommonDiseaseId",
                table: "SgPrescriptionPatientDiseaseHistory",
                column: "CommonDiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionDrugDetails_DrugRxId",
                table: "SgPrescriptionDrugDetails",
                column: "DrugRxId");

            migrationBuilder.AddForeignKey(
                name: "FK_SgPrescriptionDrugDetails_SgDrugRx_DrugRxId",
                table: "SgPrescriptionDrugDetails",
                column: "DrugRxId",
                principalTable: "SgDrugRx",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgPrescriptionPatientDiseaseHistory_SgCommonDiseases_CommonDiseaseId",
                table: "SgPrescriptionPatientDiseaseHistory",
                column: "CommonDiseaseId",
                principalTable: "SgCommonDiseases",
                principalColumn: "Id");
        }
    }
}
