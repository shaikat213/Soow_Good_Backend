using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class DiagonsticPathologyserviceMantablesfieldupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentStatus",
                table: "SgDiagonsticPathologyServiceManagements",
                newName: "ServiceRequestStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceRequestStatus",
                table: "SgDiagonsticPathologyServiceManagements",
                newName: "AppointmentStatus");
        }
    }
}
