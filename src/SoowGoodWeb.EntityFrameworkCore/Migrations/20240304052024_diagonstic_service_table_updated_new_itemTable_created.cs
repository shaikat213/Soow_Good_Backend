using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class diagonstic_service_table_updated_new_itemTable_created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DiagonsticTestRequested",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagonsticPathologyServiceManagementId = table.Column<long>(type: "bigint", nullable: true),
                    PathologyCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    PathologyTestId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagonsticTestRequested", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagonsticTestRequested_SgDiagonsticPathologyServiceManagements_DiagonsticPathologyServiceManagementId",
                        column: x => x.DiagonsticPathologyServiceManagementId,
                        principalTable: "SgDiagonsticPathologyServiceManagements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiagonsticTestRequested_SgPathologyCategory_PathologyCategoryId",
                        column: x => x.PathologyCategoryId,
                        principalTable: "SgPathologyCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiagonsticTestRequested_SgPathologyTests_PathologyTestId",
                        column: x => x.PathologyTestId,
                        principalTable: "SgPathologyTests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagonsticTestRequested_DiagonsticPathologyServiceManagementId",
                table: "DiagonsticTestRequested",
                column: "DiagonsticPathologyServiceManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagonsticTestRequested_PathologyCategoryId",
                table: "DiagonsticTestRequested",
                column: "PathologyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagonsticTestRequested_PathologyTestId",
                table: "DiagonsticTestRequested",
                column: "PathologyTestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagonsticTestRequested");

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
    }
}
