using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class DoctorDegree_TableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "SgDoctorDegrees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurationType",
                table: "SgDoctorDegrees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "SgDoctorDegrees");

            migrationBuilder.DropColumn(
                name: "DurationType",
                table: "SgDoctorDegrees");
        }
    }
}
