using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class table_names_changed_with_prefix_sg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorDegrees");

            migrationBuilder.DropTable(
                name: "DoctorSpecializations");

            migrationBuilder.DropTable(
                name: "DocumentsAttachments");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "DoctorProfiles");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.CreateTable(
                name: "SgDegrees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_SgDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SgDoctorProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorTitle = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BMDCRegNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BMDCRegExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialityId = table.Column<long>(type: "bigint", nullable: false),
                    IsIdFileUploaded = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecialityFileUploaded = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SgDoctorProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDoctorProfiles_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SgDocumentsAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityType = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    AttachmentType = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SgDocumentsAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SgSpecializations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityId = table.Column<long>(type: "bigint", nullable: true),
                    SpecializationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_SgSpecializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgSpecializations_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgDoctorDegrees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    DegreeId = table.Column<long>(type: "bigint", nullable: false),
                    InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstituteCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstituteCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_SgDoctorDegrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDoctorDegrees_SgDegrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "SgDegrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SgDoctorDegrees_SgDoctorProfiles_DoctorProfileId",
                        column: x => x.DoctorProfileId,
                        principalTable: "SgDoctorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SgDoctorSpecializations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialityId = table.Column<long>(type: "bigint", nullable: true),
                    SpecializationId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_SgDoctorSpecializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDoctorSpecializations_SgDoctorProfiles_DoctorProfileId",
                        column: x => x.DoctorProfileId,
                        principalTable: "SgDoctorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SgDoctorSpecializations_SgSpecializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "SgSpecializations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SgDoctorSpecializations_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorDegrees_DegreeId",
                table: "SgDoctorDegrees",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorDegrees_DoctorProfileId",
                table: "SgDoctorDegrees",
                column: "DoctorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorProfiles_SpecialityId",
                table: "SgDoctorProfiles",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorSpecializations_DoctorProfileId",
                table: "SgDoctorSpecializations",
                column: "DoctorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorSpecializations_SpecialityId",
                table: "SgDoctorSpecializations",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDoctorSpecializations_SpecializationId",
                table: "SgDoctorSpecializations",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_SgSpecializations_SpecialityId",
                table: "SgSpecializations",
                column: "SpecialityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SgDoctorDegrees");

            migrationBuilder.DropTable(
                name: "SgDoctorSpecializations");

            migrationBuilder.DropTable(
                name: "SgDocumentsAttachments");

            migrationBuilder.DropTable(
                name: "SgDegrees");

            migrationBuilder.DropTable(
                name: "SgDoctorProfiles");

            migrationBuilder.DropTable(
                name: "SgSpecializations");

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DegreeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BMDCRegExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BMDCRegNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoctorTitle = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsIdFileUploaded = table.Column<bool>(type: "bit", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecialityFileUploaded = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorProfiles_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentType = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    EntityType = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecializationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializations_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoctorDegrees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    InstituteCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstituteCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDegrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorDegrees_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorDegrees_DoctorProfiles_DoctorProfileId",
                        column: x => x.DoctorProfileId,
                        principalTable: "DoctorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecializations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorProfileId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialityId = table.Column<long>(type: "bigint", nullable: true),
                    SpecializationId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSpecializations_DoctorProfiles_DoctorProfileId",
                        column: x => x.DoctorProfileId,
                        principalTable: "DoctorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecializations_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorSpecializations_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDegrees_DegreeId",
                table: "DoctorDegrees",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDegrees_DoctorProfileId",
                table: "DoctorDegrees",
                column: "DoctorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorProfiles_SpecialityId",
                table: "DoctorProfiles",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecializations_DoctorProfileId",
                table: "DoctorSpecializations",
                column: "DoctorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecializations_SpecialityId",
                table: "DoctorSpecializations",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecializations_SpecializationId",
                table: "DoctorSpecializations",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_SpecialityId",
                table: "Specializations",
                column: "SpecialityId");
        }
    }
}
