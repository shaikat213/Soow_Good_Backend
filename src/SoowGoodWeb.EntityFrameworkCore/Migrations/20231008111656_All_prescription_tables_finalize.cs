using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class All_prescription_tables_finalize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SgPrescriptionDrugDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionMasterId = table.Column<long>(type: "bigint", nullable: true),
                    DrugRxId = table.Column<long>(type: "bigint", nullable: true),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SgPrescriptionDrugDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgPrescriptionDrugDetails_SgDrugRx_DrugRxId",
                        column: x => x.DrugRxId,
                        principalTable: "SgDrugRx",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SgPrescriptionDrugDetails_SgPrescriptionMaster_PrescriptionMasterId",
                        column: x => x.PrescriptionMasterId,
                        principalTable: "SgPrescriptionMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionDrugDetails_DrugRxId",
                table: "SgPrescriptionDrugDetails",
                column: "DrugRxId");

            migrationBuilder.CreateIndex(
                name: "IX_SgPrescriptionDrugDetails_PrescriptionMasterId",
                table: "SgPrescriptionDrugDetails",
                column: "PrescriptionMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SgPrescriptionDrugDetails");
        }
    }
}
