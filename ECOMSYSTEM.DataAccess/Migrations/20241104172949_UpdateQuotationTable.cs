using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOMSYSTEM.DataAccess.Migrations
{
    public partial class UpdateQuotationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__TblQuota__OrderI__5CD6CB2B",
                table: "TblQuotation");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TblQuotation");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "TblQuotation",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_TblQuotation_OrderId",
                table: "TblQuotation",
                newName: "IX_TblQuotation_ItemId");

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

            migrationBuilder.AddForeignKey(
                name: "FK__TblQuota__ItemId__5CD6CB2B",
                table: "TblQuotation",
                column: "ItemId",
                principalTable: "TblItemCart",
                principalColumn: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__TblQuota__ItemId__5CD6CB2B",
                table: "TblQuotation");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "TblQuotation",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_TblQuotation_ItemId",
                table: "TblQuotation",
                newName: "IX_TblQuotation_OrderId");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TblQuotation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__TblQuota__OrderI__5CD6CB2B",
                table: "TblQuotation",
                column: "OrderId",
                principalTable: "TblOrder",
                principalColumn: "OrderId");
        }
    }
}
