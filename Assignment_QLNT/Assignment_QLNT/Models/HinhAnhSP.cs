namespace Asm1.Models
{
    public class HinhAnhSP
    {
        public int Id { get; set; }
        public int IdSanPham { get; set; }
        public string HinhAnh {  get; set; }
        public SanPham SanPham { get; set; }
    }
}
