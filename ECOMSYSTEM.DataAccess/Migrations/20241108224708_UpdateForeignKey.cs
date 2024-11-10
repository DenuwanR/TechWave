using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOMSYSTEM.DataAccess.Migrations
{
    public partial class UpdateForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__TblQuota__ItemId__5CD6CB2B",
                table: "TblQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_TblQuotation_TblUserRegistration_UserId",
                table: "TblQuotation");

            migrationBuilder.DropIndex(
                name: "IX_TblQuotation_ItemId",
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

            migrationBuilder.AlterColumn<string>(
                name: "QuotationStatus",
                table: "TblQuotation",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TblQuotation",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblQuotation_TblItemCart_UserId",
                table: "TblQuotation",
                column: "UserId",
                principalTable: "TblItemCart",
                principalColumn: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblQuotation_TblItemCart_UserId",
                table: "TblQuotation");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "TblQuotation",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "QuotationStatus",
                table: "TblQuotation",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TblQuotation",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.CreateIndex(
                name: "IX_TblQuotation_ItemId",
                table: "TblQuotation",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK__TblQuota__ItemId__5CD6CB2B",
                table: "TblQuotation",
                column: "ItemId",
                principalTable: "TblItemCart",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblQuotation_TblUserRegistration_UserId",
                table: "TblQuotation",
                column: "UserId",
                principalTable: "TblUserRegistration",
                principalColumn: "UserId");
        }
    }
}
