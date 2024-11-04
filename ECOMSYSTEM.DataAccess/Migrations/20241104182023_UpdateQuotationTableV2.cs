using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOMSYSTEM.DataAccess.Migrations
{
    public partial class UpdateQuotationTableV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "TblQuotation",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblQuotation_UserId",
                table: "TblQuotation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblQuotation_TblUserRegistration_UserId",
                table: "TblQuotation",
                column: "UserId",
                principalTable: "TblUserRegistration",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblQuotation_TblUserRegistration_UserId",
                table: "TblQuotation");

            migrationBuilder.DropIndex(
                name: "IX_TblQuotation_UserId",
                table: "TblQuotation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TblQuotation");
        }
    }
}
