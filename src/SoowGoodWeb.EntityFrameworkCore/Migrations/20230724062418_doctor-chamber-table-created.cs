using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class doctorchambertablecreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorDegrees_SgDegrees_DegreeId",
                table: "SgDoctorDegrees");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorDegrees_SgDoctorProfiles_DoctorProfileId",
                table: "SgDoctorDegrees");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorSpecializations_SgDoctorProfiles_DoctorProfileId",
                table: "SgDoctorSpecializations");

            migrationBuilder.AlterColumn<string>(
                name: "SpecializationName",
                table: "SgSpecializations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialityName",
                table: "SgSpecialities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "OtpStatus",
                table: "SgOtps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OtpNo",
                table: "SgOtps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "SgOtps",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDateTime",
                table: "SgOtps",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "SgDocumentsAttachments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OriginalFileName",
                table: "SgDocumentsAttachments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "SgDocumentsAttachments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EntityType",
                table: "SgDocumentsAttachments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AttachmentType",
                table: "SgDocumentsAttachments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorProfileId",
                table: "SgDoctorSpecializations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorId",
                table: "SgDoctorSpecializations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "InstituteName",
                table: "SgDoctorDegrees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InstituteCountry",
                table: "SgDoctorDegrees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InstituteCity",
                table: "SgDoctorDegrees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorProfileId",
                table: "SgDoctorDegrees",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorId",
                table: "SgDoctorDegrees",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DegreeId",
                table: "SgDoctorDegrees",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "DegreeName",
                table: "SgDegrees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SgDoctorChambers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorProfileId = table.Column<long>(type: "bigint", nullable: true),
                    ChamberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SgDoctorChambers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDoctorChambers_SgDoctorProfiles_DoctorProfileId",
                        column: x => x.DoctorProfileId,
                        principalTable: "SgDoctorProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorChambers_DoctorProfileId",
                table: "SgDoctorChambers",
                column: "DoctorProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorDegrees_SgDegrees_DegreeId",
                table: "SgDoctorDegrees",
                column: "DegreeId",
                principalTable: "SgDegrees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorDegrees_SgDoctorProfiles_DoctorProfileId",
                table: "SgDoctorDegrees",
                column: "DoctorProfileId",
                principalTable: "SgDoctorProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorSpecializations_SgDoctorProfiles_DoctorProfileId",
                table: "SgDoctorSpecializations",
                column: "DoctorProfileId",
                principalTable: "SgDoctorProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorDegrees_SgDegrees_DegreeId",
                table: "SgDoctorDegrees");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorDegrees_SgDoctorProfiles_DoctorProfileId",
                table: "SgDoctorDegrees");

            migrationBuilder.DropForeignKey(
                name: "FK_SgDoctorSpecializations_SgDoctorProfiles_DoctorProfileId",
                table: "SgDoctorSpecializations");

            migrationBuilder.DropTable(
                name: "SgDoctorChambers");

            migrationBuilder.AlterColumn<string>(
                name: "SpecializationName",
                table: "SgSpecializations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpecialityName",
                table: "SgSpecialities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OtpStatus",
                table: "SgOtps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OtpNo",
                table: "SgOtps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "SgOtps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDateTime",
                table: "SgOtps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "SgDocumentsAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OriginalFileName",
                table: "SgDocumentsAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "SgDocumentsAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EntityType",
                table: "SgDocumentsAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttachmentType",
                table: "SgDocumentsAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DoctorProfileId",
                table: "SgDoctorSpecializations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DoctorId",
                table: "SgDoctorSpecializations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstituteName",
                table: "SgDoctorDegrees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstituteCountry",
                table: "SgDoctorDegrees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstituteCity",
                table: "SgDoctorDegrees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DoctorProfileId",
                table: "SgDoctorDegrees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DoctorId",
                table: "SgDoctorDegrees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DegreeId",
                table: "SgDoctorDegrees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DegreeName",
                table: "SgDegrees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorDegrees_SgDegrees_DegreeId",
                table: "SgDoctorDegrees",
                column: "DegreeId",
                principalTable: "SgDegrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorDegrees_SgDoctorProfiles_DoctorProfileId",
                table: "SgDoctorDegrees",
                column: "DoctorProfileId",
                principalTable: "SgDoctorProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SgDoctorSpecializations_SgDoctorProfiles_DoctorProfileId",
                table: "SgDoctorSpecializations",
                column: "DoctorProfileId",
                principalTable: "SgDoctorProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
