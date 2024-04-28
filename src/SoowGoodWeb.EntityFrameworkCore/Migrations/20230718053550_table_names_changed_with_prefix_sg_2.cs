using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class table_names_changed_with_prefix_sg_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorProfiles_Specialities_SpecialityId",
                table: "SgDoctorProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorSpecializations_Specialities_SpecialityId",
                table: "SgDoctorSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_SgSpecializations_Specialities_SpecialityId",
                table: "SgSpecializations");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Otps",
                table: "Otps");

            migrationBuilder.RenameTable(
                name: "Otps",
                newName: "SgOtps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SgOtps",
                table: "SgOtps",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SgSpecialities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SgSpecialities", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorProfiles_SgSpecialities_SpecialityId",
                table: "SgDoctorProfiles",
                column: "SpecialityId",
                principalTable: "SgSpecialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorSpecializations_SgSpecialities_SpecialityId",
                table: "SgDoctorSpecializations",
                column: "SpecialityId",
                principalTable: "SgSpecialities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgSpecializations_SgSpecialities_SpecialityId",
                table: "SgSpecializations",
                column: "SpecialityId",
                principalTable: "SgSpecialities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorProfiles_SgSpecialities_SpecialityId",
                table: "SgDoctorProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorSpecializations_SgSpecialities_SpecialityId",
                table: "SgDoctorSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_SgSpecializations_SgSpecialities_SpecialityId",
                table: "SgSpecializations");

            migrationBuilder.DropTable(
                name: "SgSpecialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SgOtps",
                table: "SgOtps");

            migrationBuilder.RenameTable(
                name: "SgOtps",
                newName: "Otps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Otps",
                table: "Otps",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecialityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorProfiles_Specialities_SpecialityId",
                table: "SgDoctorProfiles",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorSpecializations_Specialities_SpecialityId",
                table: "SgDoctorSpecializations",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgSpecializations_Specialities_SpecialityId",
                table: "SgSpecializations",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id");
        }
    }
}
