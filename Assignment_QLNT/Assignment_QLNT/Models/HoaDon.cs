using System;

namespace Asm1.Models
{
    public class HoaDon
    {
        public int Id { get; set; }
        public int IdNguoiDung { get; set; }
        public DateTime NgayDat { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai {  get; set; }
        public TaiKhoan TaiKhoan { get; set; }
    }
}
