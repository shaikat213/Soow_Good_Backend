using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class doctore_profile_relation_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "SgDoctorSpecializations");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "SgDoctorSchedules");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "SgDoctorDegrees");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "SgDoctorChambers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DoctorId",
                table: "SgDoctorSpecializations",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DoctorId",
                table: "SgDoctorSchedules",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DoctorId",
                table: "SgDoctorDegrees",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DoctorId",
                table: "SgDoctorChambers",
                type: "bigint",
                nullable: true);
        }
    }
}
