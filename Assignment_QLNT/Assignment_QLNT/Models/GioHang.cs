using System.Collections;
using System.Collections.Generic;

namespace Asm1.Models
{
    public class GioHang
    {
        public int Id { get; set; }
        //public int IdTaiKhoan { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public TaiKhoan TaiKhoan { get; set;}
        public SanPham SanPham { get; set; }
    }
}
