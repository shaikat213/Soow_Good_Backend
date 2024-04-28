using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class schedule_table_upated_with_inactiveDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OffDayFrom",
                table: "SgDoctorSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OffDayTo",
                table: "SgDoctorSchedules",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffDayFrom",
                table: "SgDoctorSchedules");

            migrationBuilder.DropColumn(
                name: "OffDayTo",
                table: "SgDoctorSchedules");
        }
    }
}
