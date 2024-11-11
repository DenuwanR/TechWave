using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOMSYSTEM.DataAccess.Migrations
{
    public partial class AddSupplierQuoteTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "QuotationAmount",
                table: "TblQuotation");

            migrationBuilder.DropColumn(
                name: "QuotationStatus",
                table: "TblQuotation");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "TblQuotation");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "TblQuotation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TblQuotation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TblSupplierQuote",
                columns: table => new
                {
                    SupplierQuoteId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationId = table.Column<long>(type: "bigint", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    QuotationAmount = table.Column<double>(type: "float", nullable: false),
                    QuotationStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblSuppo__2A5B08B07946F69D", x => x.SupplierQuoteId);
                    table.ForeignKey(
                        name: "FK_TblSupplierQuote_TblQuotation_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "TblQuotation",
                        principalColumn: "QuotationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblSupplierQuote_QuotationId",
                table: "TblSupplierQuote",
                column: "QuotationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblSupplierQuote");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "TblQuotation",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TblQuotation",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<double>(
                name: "QuotationAmount",
                table: "TblQuotation",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "QuotationStatus",
                table: "TblQuotation",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                table: "TblQuotation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TblQuotation_SupplierId",
                table: "TblQuotation",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TblQuotation_UserId",
                table: "TblQuotation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK__TblQuota__Suppli__4AB81AF0",
                table: "TblQuotation",
                column: "SupplierId",
                principalTable: "TblUserRegistration",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblQuotation_TblUserRegistration_UserId",
                table: "TblQuotation",
                column: "UserId",
                principalTable: "TblUserRegistration",
                principalColumn: "UserId");
        }
    }
}
