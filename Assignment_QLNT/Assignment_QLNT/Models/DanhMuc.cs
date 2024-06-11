using System.Collections;
using System.Collections.Generic;

namespace Asm1.Models
{
    public class DanhMuc
    {
        public int Id { get; set; }
        public string TenDanhMuc { get; set; }
        public ICollection<SanPham> SanPham { get; set; }

    }
}
