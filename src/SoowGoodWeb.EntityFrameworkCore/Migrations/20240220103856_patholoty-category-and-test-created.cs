using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class patholotycategoryandtestcreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PathologyTest_PathologyCategory_PathologyCategoryId",
                table: "PathologyTest");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticPackageTests_PathologyCategory_PathologyCategoryId",
                table: "SgDiagonsticPackageTests");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticPackageTests_PathologyTest_PathologyTestId",
                table: "SgDiagonsticPackageTests");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticTests_PathologyCategory_PathologyCategoryId",
                table: "SgDiagonsticTests");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticTests_PathologyTest_PathologyTestId",
                table: "SgDiagonsticTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PathologyTest",
                table: "PathologyTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PathologyCategory",
                table: "PathologyCategory");

            migrationBuilder.RenameTable(
                name: "PathologyTest",
                newName: "SgPathologyTests");

            migrationBuilder.RenameTable(
                name: "PathologyCategory",
                newName: "SgPathologyCategory");

            migrationBuilder.RenameIndex(
                name: "IX_PathologyTest_PathologyCategoryId",
                table: "SgPathologyTests",
                newName: "IX_SgPathologyTests_PathologyCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SgPathologyTests",
                table: "SgPathologyTests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SgPathologyCategory",
                table: "SgPathologyCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticPackageTests_SgPathologyCategory_PathologyCategoryId",
                table: "SgDiagonsticPackageTests",
                column: "PathologyCategoryId",
                principalTable: "SgPathologyCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticPackageTests_SgPathologyTests_PathologyTestId",
                table: "SgDiagonsticPackageTests",
                column: "PathologyTestId",
                principalTable: "SgPathologyTests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticTests_SgPathologyCategory_PathologyCategoryId",
                table: "SgDiagonsticTests",
                column: "PathologyCategoryId",
                principalTable: "SgPathologyCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticTests_SgPathologyTests_PathologyTestId",
                table: "SgDiagonsticTests",
                column: "PathologyTestId",
                principalTable: "SgPathologyTests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgPathologyTests_SgPathologyCategory_PathologyCategoryId",
                table: "SgPathologyTests",
                column: "PathologyCategoryId",
                principalTable: "SgPathologyCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticPackageTests_SgPathologyCategory_PathologyCategoryId",
                table: "SgDiagonsticPackageTests");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticPackageTests_SgPathologyTests_PathologyTestId",
                table: "SgDiagonsticPackageTests");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticTests_SgPathologyCategory_PathologyCategoryId",
                table: "SgDiagonsticTests");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDiagonsticTests_SgPathologyTests_PathologyTestId",
                table: "SgDiagonsticTests");

            migrationBuilder.DropForeignKey(
                name: "FK_SgPathologyTests_SgPathologyCategory_PathologyCategoryId",
                table: "SgPathologyTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SgPathologyTests",
                table: "SgPathologyTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SgPathologyCategory",
                table: "SgPathologyCategory");

            migrationBuilder.RenameTable(
                name: "SgPathologyTests",
                newName: "PathologyTest");

            migrationBuilder.RenameTable(
                name: "SgPathologyCategory",
                newName: "PathologyCategory");

            migrationBuilder.RenameIndex(
                name: "IX_SgPathologyTests_PathologyCategoryId",
                table: "PathologyTest",
                newName: "IX_PathologyTest_PathologyCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PathologyTest",
                table: "PathologyTest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PathologyCategory",
                table: "PathologyCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PathologyTest_PathologyCategory_PathologyCategoryId",
                table: "PathologyTest",
                column: "PathologyCategoryId",
                principalTable: "PathologyCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticPackageTests_PathologyCategory_PathologyCategoryId",
                table: "SgDiagonsticPackageTests",
                column: "PathologyCategoryId",
                principalTable: "PathologyCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticPackageTests_PathologyTest_PathologyTestId",
                table: "SgDiagonsticPackageTests",
                column: "PathologyTestId",
                principalTable: "PathologyTest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticTests_PathologyCategory_PathologyCategoryId",
                table: "SgDiagonsticTests",
                column: "PathologyCategoryId",
                principalTable: "PathologyCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDiagonsticTests_PathologyTest_PathologyTestId",
                table: "SgDiagonsticTests",
                column: "PathologyTestId",
                principalTable: "PathologyTest",
                principalColumn: "Id");
        }
    }
}
