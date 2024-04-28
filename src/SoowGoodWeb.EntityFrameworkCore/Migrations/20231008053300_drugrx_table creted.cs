using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class drugrx_tablecreted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SgDrugRx",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenericName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosageForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InclusionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VlidUpto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CDAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SgDrugRx", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SgDrugRx");
        }
    }
}
