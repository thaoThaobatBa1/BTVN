using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gioHangs",
                columns: table => new
                {
                    gioHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tongSoLuongSanPham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gioHangs", x => x.gioHangId);
                });

            migrationBuilder.CreateTable(
                name: "sanpham",
                columns: table => new
                {
                    sanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanpham", x => x.sanPhamId);
                });

            migrationBuilder.CreateTable(
                name: "gHCTs",
                columns: table => new
                {
                    GhctId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    gioHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    giaDonVi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gHCTs", x => x.GhctId);
                    table.ForeignKey(
                        name: "FK_gHCTs_gioHangs_gioHangId",
                        column: x => x.gioHangId,
                        principalTable: "gioHangs",
                        principalColumn: "gioHangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gHCTs_sanpham_sanPhamId",
                        column: x => x.sanPhamId,
                        principalTable: "sanpham",
                        principalColumn: "sanPhamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gHCTs_gioHangId",
                table: "gHCTs",
                column: "gioHangId");

            migrationBuilder.CreateIndex(
                name: "IX_gHCTs_sanPhamId",
                table: "gHCTs",
                column: "sanPhamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gHCTs");

            migrationBuilder.DropTable(
                name: "gioHangs");

            migrationBuilder.DropTable(
                name: "sanpham");
        }
    }
}
