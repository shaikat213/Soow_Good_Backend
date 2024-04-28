using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class doctor_schedule_table_Schedule_name_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScheduleName",
                table: "SgDoctorSchedules",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleName",
                table: "SgDoctorSchedules");
        }
    }
}
