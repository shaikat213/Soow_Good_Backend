using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class diagonstic_testrequestedtablenameupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagonsticTestRequested_SgDiagonsticPathologyServiceManagements_DiagonsticPathologyServiceManagementId",
                table: "DiagonsticTestRequested");

            migrationBuilder.DropForeignKey(
                name: "FK_DiagonsticTestRequested_SgDiagonsticTests_DiagonsticTestId",
                table: "DiagonsticTestRequested");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiagonsticTestRequested",
                table: "DiagonsticTestRequested");

            migrationBuilder.RenameTable(
                name: "DiagonsticTestRequested",
                newName: "SgDiagonsticTestRequested");

            migrationBuilder.RenameIndex(
                name: "IX_DiagonsticTestRequested_DiagonsticTestId",
                table: "SgDiagonsticTestRequested",
                newName: "IX_SgDiagonsticTestRequested_DiagonsticTestId");

            migrationBuilder.RenameIndex(
                name: "IX_DiagonsticTestRequested_DiagonsticPathologyServiceManagementId",
                table: "SgDiagonsticTestRequested",
                newName: "IX_SgDiagonsticTestRequested_DiagonsticPathologyServiceManagementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SgDiagonsticTestRequested",
                table: "SgDiagonsticTestRequested",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticTestRequested_SgDiagonsticPathologyServiceManagements_DiagonsticPathologyServiceManagementId",
                table: "SgDiagonsticTestRequested",
                column: "DiagonsticPathologyServiceManagementId",
                principalTable: "SgDiagonsticPathologyServiceManagements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticTestRequested_SgDiagonsticTests_DiagonsticTestId",
                table: "SgDiagonsticTestRequested",
                column: "DiagonsticTestId",
                principalTable: "SgDiagonsticTests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticTestRequested_SgDiagonsticPathologyServiceManagements_DiagonsticPathologyServiceManagementId",
                table: "SgDiagonsticTestRequested");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticTestRequested_SgDiagonsticTests_DiagonsticTestId",
                table: "SgDiagonsticTestRequested");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SgDiagonsticTestRequested",
                table: "SgDiagonsticTestRequested");

            migrationBuilder.RenameTable(
                name: "SgDiagonsticTestRequested",
                newName: "DiagonsticTestRequested");

            migrationBuilder.RenameIndex(
                name: "IX_SgDiagonsticTestRequested_DiagonsticTestId",
                table: "DiagonsticTestRequested",
                newName: "IX_DiagonsticTestRequested_DiagonsticTestId");

            migrationBuilder.RenameIndex(
                name: "IX_SgDiagonsticTestRequested_DiagonsticPathologyServiceManagementId",
                table: "DiagonsticTestRequested",
                newName: "IX_DiagonsticTestRequested_DiagonsticPathologyServiceManagementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiagonsticTestRequested",
                table: "DiagonsticTestRequested",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagonsticTestRequested_SgDiagonsticPathologyServiceManagements_DiagonsticPathologyServiceManagementId",
                table: "DiagonsticTestRequested",
                column: "DiagonsticPathologyServiceManagementId",
                principalTable: "SgDiagonsticPathologyServiceManagements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagonsticTestRequested_SgDiagonsticTests_DiagonsticTestId",
                table: "DiagonsticTestRequested",
                column: "DiagonsticTestId",
                principalTable: "SgDiagonsticTests",
                principalColumn: "Id");
        }
    }
}
