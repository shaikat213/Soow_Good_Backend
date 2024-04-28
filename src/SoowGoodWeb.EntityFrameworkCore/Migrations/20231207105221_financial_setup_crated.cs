using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class financial_setup_crated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SgFinancialSetups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformFacilitiesId = table.Column<long>(type: "bigint", nullable: true),
                    PlatformFacilityId = table.Column<long>(type: "bigint", nullable: true),
                    AmountIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExternalAmountIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActivie = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_SgFinancialSetups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgFinancialSetups_SgPlatformFacilities_PlatformFacilityId",
                        column: x => x.PlatformFacilityId,
                        principalTable: "SgPlatformFacilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SgFinancialSetups_PlatformFacilityId",
                table: "SgFinancialSetups",
                column: "PlatformFacilityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SgFinancialSetups");
        }
    }
}
