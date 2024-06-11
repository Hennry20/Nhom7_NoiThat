using Microsoft.EntityFrameworkCore.Migrations;

namespace Asm1.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_GioHang_TaiKhoan_TaiKhoanId",
            //    table: "GioHang");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_SanPham_LoaiSanPham_IdLoaiSP",
            //    table: "SanPham");

            //migrationBuilder.DropTable(
            //    name: "LoaiSanPham");

            //migrationBuilder.DropIndex(
            //    name: "IX_SanPham_IdLoaiSP",
            //    table: "SanPham");

            //migrationBuilder.DropIndex(
            //    name: "IX_GioHang_TaiKhoanId",
            //    table: "GioHang");

            //migrationBuilder.DropColumn(
            //    name: "IdLoaiSP",
            //    table: "SanPham");

            //migrationBuilder.DropColumn(
            //    name: "TaiKhoanId",
            //    table: "GioHang");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GioHang_IdTaiKhoan",
            //    table: "GioHang",
            //    column: "IdTaiKhoan");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_GioHang_TaiKhoan_IdTaiKhoan",
            //    table: "GioHang",
            //    column: "IdTaiKhoan",
            //    principalTable: "TaiKhoan",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_GioHang_TaiKhoan_IdTaiKhoan",
            //    table: "GioHang");

            //migrationBuilder.DropIndex(
            //    name: "IX_GioHang_IdTaiKhoan",
            //    table: "GioHang");

            //migrationBuilder.AddColumn<int>(
            //    name: "IdLoaiSP",
            //    table: "SanPham",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "TaiKhoanId",
            //    table: "GioHang",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "LoaiSanPham",
            //    columns: table => new
            //    {
            //        IdLoai = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdDanhMuc = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LoaiSanPham", x => x.IdLoai);
            //        table.ForeignKey(
            //            name: "FK_LoaiSanPham_DanhMuc_IdDanhMuc",
            //            column: x => x.IdDanhMuc,
            //            principalTable: "DanhMuc",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_SanPham_IdLoaiSP",
            //    table: "SanPham",
            //    column: "IdLoaiSP");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GioHang_TaiKhoanId",
            //    table: "GioHang",
            //    column: "TaiKhoanId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LoaiSanPham_IdDanhMuc",
            //    table: "LoaiSanPham",
            //    column: "IdDanhMuc");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_GioHang_TaiKhoan_TaiKhoanId",
            //    table: "GioHang",
            //    column: "TaiKhoanId",
            //    principalTable: "TaiKhoan",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SanPham_LoaiSanPham_IdLoaiSP",
            //    table: "SanPham",
            //    column: "IdLoaiSP",
            //    principalTable: "LoaiSanPham",
            //    principalColumn: "IdLoai",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
