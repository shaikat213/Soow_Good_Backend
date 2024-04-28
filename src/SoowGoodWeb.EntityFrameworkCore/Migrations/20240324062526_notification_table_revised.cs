using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class notification_table_revised : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateForName",
                table: "SgNotification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatorEntityId",
                table: "SgNotification",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorName",
                table: "SgNotification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorRole",
                table: "SgNotification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoticeFromEntity",
                table: "SgNotification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NoticeFromEntityId",
                table: "SgNotification",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NotifyToEntityId",
                table: "SgNotification",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotifyToName",
                table: "SgNotification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotifyToRole",
                table: "SgNotification",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateForName",
                table: "SgNotification");

            migrationBuilder.DropColumn(
                name: "CreatorEntityId",
                table: "SgNotification");

            migrationBuilder.DropColumn(
                name: "CreatorName",
                table: "SgNotification");

            migrationBuilder.DropColumn(
                name: "CreatorRole",
                table: "SgNotification");

            migrationBuilder.DropColumn(
                name: "NoticeFromEntity",
                table: "SgNotification");

            migrationBuilder.DropColumn(
                name: "NoticeFromEntityId",
                table: "SgNotification");

            migrationBuilder.DropColumn(
                name: "NotifyToEntityId",
                table: "SgNotification");

            migrationBuilder.DropColumn(
                name: "NotifyToName",
                table: "SgNotification");

            migrationBuilder.DropColumn(
                name: "NotifyToRole",
                table: "SgNotification");
        }
    }
}
