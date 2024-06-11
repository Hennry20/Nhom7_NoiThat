using Microsoft.EntityFrameworkCore.Migrations;

namespace Asm1.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_GioHang_GioHangId",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_GioHangId",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "GioHangId",
                table: "SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_IdSanPham",
                table: "GioHang",
                column: "IdSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_GioHang_SanPham_IdSanPham",
                table: "GioHang",
                column: "IdSanPham",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHang_SanPham_IdSanPham",
                table: "GioHang");

            migrationBuilder.DropIndex(
                name: "IX_GioHang_IdSanPham",
                table: "GioHang");

            migrationBuilder.AddColumn<int>(
                name: "GioHangId",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_GioHangId",
                table: "SanPham",
                column: "GioHangId");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_GioHang_GioHangId",
                table: "SanPham",
                column: "GioHangId",
                principalTable: "GioHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
