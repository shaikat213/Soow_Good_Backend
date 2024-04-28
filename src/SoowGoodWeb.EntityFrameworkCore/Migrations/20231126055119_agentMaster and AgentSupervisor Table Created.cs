using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class agentMasterandAgentSupervisorTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AgentDocExpireDate",
                table: "SgAgentProfiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentDocNumber",
                table: "SgAgentProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AgentMasterId",
                table: "SgAgentProfiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AgentSupervisorId",
                table: "SgAgentProfiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SgAgentMasters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentMasterOrgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentMasterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonOfficeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonIdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersongMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentMasterDocNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentMasterDocExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_SgAgentMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SgAgentSupervisors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentMasterId = table.Column<long>(type: "bigint", nullable: true),
                    AgentSupervisorOrgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentSupervisorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorIdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentSupervisorDocNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentSupervisorDocExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_SgAgentSupervisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgAgentSupervisors_SgAgentMasters_AgentMasterId",
                        column: x => x.AgentMasterId,
                        principalTable: "SgAgentMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SgAgentProfiles_AgentMasterId",
                table: "SgAgentProfiles",
                column: "AgentMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SgAgentProfiles_AgentSupervisorId",
                table: "SgAgentProfiles",
                column: "AgentSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_SgAgentSupervisors_AgentMasterId",
                table: "SgAgentSupervisors",
                column: "AgentMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SgAgentProfiles_SgAgentMasters_AgentMasterId",
                table: "SgAgentProfiles",
                column: "AgentMasterId",
                principalTable: "SgAgentMasters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SgAgentProfiles_SgAgentSupervisors_AgentSupervisorId",
                table: "SgAgentProfiles",
                column: "AgentSupervisorId",
                principalTable: "SgAgentSupervisors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SgAgentProfiles_SgAgentMasters_AgentMasterId",
                table: "SgAgentProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_SgAgentProfiles_SgAgentSupervisors_AgentSupervisorId",
                table: "SgAgentProfiles");

            migrationBuilder.DropTable(
                name: "SgAgentSupervisors");

            migrationBuilder.DropTable(
                name: "SgAgentMasters");

            migrationBuilder.DropIndex(
                name: "IX_SgAgentProfiles_AgentMasterId",
                table: "SgAgentProfiles");

            migrationBuilder.DropIndex(
                name: "IX_SgAgentProfiles_AgentSupervisorId",
                table: "SgAgentProfiles");

            migrationBuilder.DropColumn(
                name: "AgentDocExpireDate",
                table: "SgAgentProfiles");

            migrationBuilder.DropColumn(
                name: "AgentDocNumber",
                table: "SgAgentProfiles");

            migrationBuilder.DropColumn(
                name: "AgentMasterId",
                table: "SgAgentProfiles");

            migrationBuilder.DropColumn(
                name: "AgentSupervisorId",
                table: "SgAgentProfiles");
        }
    }
}
