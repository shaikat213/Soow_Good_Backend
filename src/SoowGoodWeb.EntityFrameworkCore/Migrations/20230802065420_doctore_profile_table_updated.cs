using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class doctore_profile_table_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createFrom",
                table: "SgDoctorProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "profileStep",
                table: "SgDoctorProfiles",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createFrom",
                table: "SgDoctorProfiles");

            migrationBuilder.DropColumn(
                name: "profileStep",
                table: "SgDoctorProfiles");
        }
    }
}
