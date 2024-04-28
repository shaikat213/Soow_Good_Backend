using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoowGoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class Payment_Tables_Created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SgPaymentHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    application_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sessionkey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tran_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tran_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    val_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    store_amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank_tran_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_issuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_issuer_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_issuer_country_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency_amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    base_fair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value_a = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value_b = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value_c = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value_d = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emi_instalment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emi_amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emi_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emi_issuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account_details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    risk_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    risk_level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APIConnect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    validated_on = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gw_version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    failedreason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    error = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_sub_brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subscription_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SgPaymentHistory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SgPaymentHistory");
        }
    }
}
