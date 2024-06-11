using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asm1.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        public int IdDanhMuc { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string MoTa { get; set; }
        public string VatLieu { get; set; }
        public int SoLuong { get; set; }
        public string KichThuoc { get; set; }
        public string HinhAnh { get; set; }
        public ICollection<HinhAnhSP>? HinhAnhSP {  get; set; }
        public DanhMuc DanhMuc { get; set; }
        public ICollection<GioHang> GioHangs { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        
    }
}
