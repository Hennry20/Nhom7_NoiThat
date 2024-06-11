using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm1.Models
{
    public class TaiKhoan
    {
        public int Id { get; set; }
        public string TenND { get; set; }
        public string HinhAnh {  get; set; }

        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string Diachi { get; set; }
        public string SDT { get; set;}
        public string GioiTinh { get; set; }
        public string VaiTro { get; set; }
        public ICollection<GioHang> GioHang { get; set;}
    }
}
