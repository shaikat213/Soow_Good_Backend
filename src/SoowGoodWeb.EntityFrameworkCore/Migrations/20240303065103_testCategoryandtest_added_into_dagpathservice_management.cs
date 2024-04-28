using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class testCategoryandtest_added_into_dagpathservice_management : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DiagonsticTestId",
                table: "SgDiagonsticPathologyServiceManagements",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SgDiagonsticPathologyServiceManagements_DiagonsticTestId",
                table: "SgDiagonsticPathologyServiceManagements",
                column: "DiagonsticTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticPathologyServiceManagements_SgDiagonsticTests_DiagonsticTestId",
                table: "SgDiagonsticPathologyServiceManagements",
                column: "DiagonsticTestId",
                principalTable: "SgDiagonsticTests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticPathologyServiceManagements_SgDiagonsticTests_DiagonsticTestId",
                table: "SgDiagonsticPathologyServiceManagements");

            migrationBuilder.DropIndex(
                name: "IX_SgDiagonsticPathologyServiceManagements_DiagonsticTestId",
                table: "SgDiagonsticPathologyServiceManagements");

            migrationBuilder.DropColumn(
                name: "DiagonsticTestId",
                table: "SgDiagonsticPathologyServiceManagements");
        }
    }
}
