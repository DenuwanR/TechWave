using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOMSYSTEM.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblProducts",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__B40CC6CD8808E9F9", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "TblUserRegistration",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MobileNo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblUserR__1788CC4CA80DDAD3", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TblItemCart",
                columns: table => new
                {
                    ItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ItemPrice = table.Column<double>(type: "float", nullable: true),
                    ItemQTY = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsInCart = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__727E838B36C57308", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK__TblItemCa__Produ__5CD6CB2B",
                        column: x => x.ProductId,
                        principalTable: "TblProducts",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK__TblItemCa__UserI__4AB81AF0",
                        column: x => x.UserId,
                        principalTable: "TblUserRegistration",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TblOrder",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OderValue = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsOrderAccept = table.Column<bool>(type: "bit", nullable: true),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblOrder__C3905BCF4ABEA67D", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK__TblOrder__ItemId__4D94879B",
                        column: x => x.ItemId,
                        principalTable: "TblItemCart",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK__TblOrder__UserId__4E88ABD4",
                        column: x => x.UserId,
                        principalTable: "TblUserRegistration",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TblQuotation",
                columns: table => new
                {
                    QuotationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    QuotationAmount = table.Column<double>(type: "float", nullable: false),
                    QuotationStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblQuota__2B1397A1D476A42B", x => x.QuotationId);
                    table.ForeignKey(
                        name: "FK__TblQuota__OrderI__5CD6CB2B",
                        column: x => x.OrderId,
                        principalTable: "TblOrder",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK__TblQuota__Suppli__4AB81AF0",
                        column: x => x.SupplierId,
                        principalTable: "TblUserRegistration",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblItemCart_ProductId",
                table: "TblItemCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TblItemCart_UserId",
                table: "TblItemCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrder_ItemId",
                table: "TblOrder",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrder_UserId",
                table: "TblOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblQuotation_OrderId",
                table: "TblQuotation",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TblQuotation_SupplierId",
                table: "TblQuotation",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblQuotation");

            migrationBuilder.DropTable(
                name: "TblOrder");

            migrationBuilder.DropTable(
                name: "TblItemCart");

            migrationBuilder.DropTable(
                name: "TblProducts");

            migrationBuilder.DropTable(
                name: "TblUserRegistration");
        }
    }
}
