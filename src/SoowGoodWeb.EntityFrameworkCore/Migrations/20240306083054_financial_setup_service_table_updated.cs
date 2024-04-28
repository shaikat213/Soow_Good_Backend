using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class financial_setup_service_table_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FacilityEntityID",
                table: "SgFinancialSetups",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacilityEntityType",
                table: "SgFinancialSetups",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacilityEntityID",
                table: "SgFinancialSetups");

            migrationBuilder.DropColumn(
                name: "FacilityEntityType",
                table: "SgFinancialSetups");
        }
    }
}
