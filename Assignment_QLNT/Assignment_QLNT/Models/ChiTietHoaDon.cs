using System;
using System.Collections.Generic;

namespace Asm1.Models
{
    public class ChiTietHoaDon
    {
        public int Id { get; set; }
        public int IdHoaDon {  get; set; }
        public int IdSanPham {  get; set; }
        public int SoLuong { get; set; }
        public HoaDon HoaDon { get; set; }
        public SanPham SanPham { get; set; }
    }
}
