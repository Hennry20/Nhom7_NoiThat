using Microsoft.EntityFrameworkCore.Migrations;

namespace Asm1.Migrations
{
    public partial class ThemHinhAnhTK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "TaiKhoan");
        }
    }
}
