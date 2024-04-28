using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class Diagonsticservicetablescreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiagonsticServiceType",
                table: "SgFinancialSetups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PathologyCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathologyCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathologyCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PathologyCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SgDiagonsticPackages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderId = table.Column<long>(type: "bigint", nullable: true),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_SgDiagonsticPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDiagonsticPackages_SgServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "SgServiceProviders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PathologyTest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathologyCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    PathologyTestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathologyTestDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PathologyTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PathologyTest_PathologyCategory_PathologyCategoryId",
                        column: x => x.PathologyCategoryId,
                        principalTable: "PathologyCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgDiagonsticPathologyServiceManagements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceRequestCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceProviderId = table.Column<long>(type: "bigint", nullable: true),
                    DiagonsticServiceType = table.Column<int>(type: "int", nullable: true),
                    DiagonsticPackageId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientProfileId = table.Column<long>(type: "bigint", nullable: true),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProviderFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FinalFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AppointmentStatus = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_SgDiagonsticPathologyServiceManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDiagonsticPathologyServiceManagements_SgDiagonsticPackages_DiagonsticPackageId",
                        column: x => x.DiagonsticPackageId,
                        principalTable: "SgDiagonsticPackages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SgDiagonsticPathologyServiceManagements_SgServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "SgServiceProviders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgDiagonsticPackageTests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagonsticPackageId = table.Column<long>(type: "bigint", nullable: true),
                    PathologyCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    PathologyTestId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_SgDiagonsticPackageTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDiagonsticPackageTests_PathologyCategory_PathologyCategoryId",
                        column: x => x.PathologyCategoryId,
                        principalTable: "PathologyCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SgDiagonsticPackageTests_PathologyTest_PathologyTestId",
                        column: x => x.PathologyTestId,
                        principalTable: "PathologyTest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SgDiagonsticPackageTests_SgDiagonsticPackages_DiagonsticPackageId",
                        column: x => x.DiagonsticPackageId,
                        principalTable: "SgDiagonsticPackages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgDiagonsticTests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderId = table.Column<long>(type: "bigint", nullable: true),
                    PathologyCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    PathologyTestId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_SgDiagonsticTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgDiagonsticTests_PathologyCategory_PathologyCategoryId",
                        column: x => x.PathologyCategoryId,
                        principalTable: "PathologyCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SgDiagonsticTests_PathologyTest_PathologyTestId",
                        column: x => x.PathologyTestId,
                        principalTable: "PathologyTest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SgDiagonsticTests_SgServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "SgServiceProviders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PathologyTest_PathologyCategoryId",
                table: "PathologyTest",
                column: "PathologyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDiagonsticPackages_ServiceProviderId",
                table: "SgDiagonsticPackages",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDiagonsticPackageTests_DiagonsticPackageId",
                table: "SgDiagonsticPackageTests",
                column: "DiagonsticPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDiagonsticPackageTests_PathologyCategoryId",
                table: "SgDiagonsticPackageTests",
                column: "PathologyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDiagonsticPackageTests_PathologyTestId",
                table: "SgDiagonsticPackageTests",
                column: "PathologyTestId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDiagonsticPathologyServiceManagements_DiagonsticPackageId",
                table: "SgDiagonsticPathologyServiceManagements",
                column: "DiagonsticPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDiagonsticPathologyServiceManagements_ServiceProviderId",
                table: "SgDiagonsticPathologyServiceManagements",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDiagonsticTests_PathologyCategoryId",
                table: "SgDiagonsticTests",
                column: "PathologyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDiagonsticTests_PathologyTestId",
                table: "SgDiagonsticTests",
                column: "PathologyTestId");

            migrationBuilder.CreateIndex(
                name: "IX_SgDiagonsticTests_ServiceProviderId",
                table: "SgDiagonsticTests",
                column: "ServiceProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SgDiagonsticPackageTests");

            migrationBuilder.DropTable(
                name: "SgDiagonsticPathologyServiceManagements");

            migrationBuilder.DropTable(
                name: "SgDiagonsticTests");

            migrationBuilder.DropTable(
                name: "SgDiagonsticPackages");

            migrationBuilder.DropTable(
                name: "PathologyTest");

            migrationBuilder.DropTable(
                name: "PathologyCategory");

            migrationBuilder.DropColumn(
                name: "DiagonsticServiceType",
                table: "SgFinancialSetups");
        }
    }
}
