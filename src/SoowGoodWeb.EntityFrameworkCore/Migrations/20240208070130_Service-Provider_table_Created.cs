using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class ServiceProvider_table_Created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SgServiceProviders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformFacilityId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderOrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationAvailability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_SgServiceProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgServiceProviders_SgPlatformFacilities_PlatformFacilityId",
                        column: x => x.PlatformFacilityId,
                        principalTable: "SgPlatformFacilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SgServiceProviders_PlatformFacilityId",
                table: "SgServiceProviders",
                column: "PlatformFacilityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SgServiceProviders");
        }
    }
}
