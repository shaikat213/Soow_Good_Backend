using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class financialsetuptableupdatedvat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActivie",
                table: "SgFinancialSetups",
                newName: "IsActive");

            migrationBuilder.AddColumn<int>(
                name: "Vat",
                table: "SgFinancialSetups",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vat",
                table: "SgFinancialSetups");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "SgFinancialSetups",
                newName: "IsActivie");
        }
    }
}
