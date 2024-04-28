using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class diagonstic_service_management_table_updated_with_diagonstic_Test_request : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagonsticTestRequested_SgPathologyCategory_PathologyCategoryId",
                table: "DiagonsticTestRequested");

            migrationBuilder.DropForeignKey(
                name: "FK_DiagonsticTestRequested_SgPathologyTests_PathologyTestId",
                table: "DiagonsticTestRequested");

            migrationBuilder.DropIndex(
                name: "IX_DiagonsticTestRequested_PathologyCategoryId",
                table: "DiagonsticTestRequested");

            migrationBuilder.DropColumn(
                name: "PathologyCategoryId",
                table: "DiagonsticTestRequested");

            migrationBuilder.RenameColumn(
                name: "PathologyTestId",
                table: "DiagonsticTestRequested",
                newName: "DiagonsticTestId");

            migrationBuilder.RenameIndex(
                name: "IX_DiagonsticTestRequested_PathologyTestId",
                table: "DiagonsticTestRequested",
                newName: "IX_DiagonsticTestRequested_DiagonsticTestId");

            migrationBuilder.AddColumn<string>(
                name: "PathologyCategoryAndTest",
                table: "DiagonsticTestRequested",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DiagonsticTestRequested_SgDiagonsticTests_DiagonsticTestId",
                table: "DiagonsticTestRequested",
                column: "DiagonsticTestId",
                principalTable: "SgDiagonsticTests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagonsticTestRequested_SgDiagonsticTests_DiagonsticTestId",
                table: "DiagonsticTestRequested");

            migrationBuilder.DropColumn(
                name: "PathologyCategoryAndTest",
                table: "DiagonsticTestRequested");

            migrationBuilder.RenameColumn(
                name: "DiagonsticTestId",
                table: "DiagonsticTestRequested",
                newName: "PathologyTestId");

            migrationBuilder.RenameIndex(
                name: "IX_DiagonsticTestRequested_DiagonsticTestId",
                table: "DiagonsticTestRequested",
                newName: "IX_DiagonsticTestRequested_PathologyTestId");

            migrationBuilder.AddColumn<long>(
                name: "PathologyCategoryId",
                table: "DiagonsticTestRequested",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiagonsticTestRequested_PathologyCategoryId",
                table: "DiagonsticTestRequested",
                column: "PathologyCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagonsticTestRequested_SgPathologyCategory_PathologyCategoryId",
                table: "DiagonsticTestRequested",
                column: "PathologyCategoryId",
                principalTable: "SgPathologyCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagonsticTestRequested_SgPathologyTests_PathologyTestId",
                table: "DiagonsticTestRequested",
                column: "PathologyTestId",
                principalTable: "SgPathologyTests",
                principalColumn: "Id");
        }
    }
}
