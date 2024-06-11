using Asm1.Models;
using Microsoft.EntityFrameworkCore;

namespace Asm1.DATA
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<GioHang> GioHang { get; set; }
        public DbSet<HinhAnhSP> HinhAnhSP { get; set; }
        public DbSet<ChiTietHoaDon> chiTietHoaDons { get; set; }
        public DbSet<DanhMuc> DanhMuc { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SanPham>().HasKey(e => e.Id);
            modelBuilder.Entity<TaiKhoan>().HasKey(e => e.Id);
            modelBuilder.Entity<HinhAnhSP>().HasKey(e => e.Id);
            modelBuilder.Entity<HoaDon>().HasKey(e => e.Id);
            modelBuilder.Entity<GioHang>().HasKey(e => e.Id);
            modelBuilder.Entity<ChiTietHoaDon>().HasKey(e => e.Id);
            modelBuilder.Entity<DanhMuc>().HasKey(e => e.Id);
            

            //Quan he 1 - nhieu SanPham - DanhMuc
            modelBuilder.Entity<SanPham>()
                .HasOne<DanhMuc>(e => e.DanhMuc)
                .WithMany(d => d.SanPham)
                .HasForeignKey(c => c.IdDanhMuc);

            //Quan he 1 - nhieu HinhAnhSp - SanPham
            modelBuilder.Entity<HinhAnhSP>()
                .HasOne<SanPham>(a => a.SanPham)
                .WithMany(l => l.HinhAnhSP)
                .HasForeignKey(b => b.IdSanPham);

            modelBuilder.Entity<GioHang>()
                .HasOne<SanPham>(a => a.SanPham)
                .WithMany(l => l.GioHangs)
                .HasForeignKey(b => b.IdSanPham);

            //Quan he 1 - nhieu San Pham - ChiTietHoaDon
            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne<SanPham>(a => a.SanPham)
                .WithMany(l => l.ChiTietHoaDons)
                .HasForeignKey(b => b.IdSanPham);

            //modelBuilder.Entity<GioHang>()
            //    .HasOne<TaiKhoan>(a => a.TaiKhoan)
            //    .WithMany(l => l.GioHang)
            //    .HasForeignKey(b => b.IdTaiKhoan);
        }
    }
}
