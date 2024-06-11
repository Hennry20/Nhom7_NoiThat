using Asm1.DATA;
using Asm1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Asm1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            List<SanPham> sanPhams = _applicationDbContext.SanPham.ToList();

            return View(sanPhams);
            //var sp = _applicationDbContext.DanhMuc.Include(dm=>dm.SanPham).ToList();
            //return View(sp);
        }

        public IActionResult LienHe()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangNhap(string username, string password)
        {
            var user = _applicationDbContext.TaiKhoan.FirstOrDefault(s=>s.TenND == username && s.MatKhau == password);
            if(user != null)
            {
                if(user.VaiTro == "user")
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("Username", user.TenND);
                    return RedirectToAction("TaiKhoan");
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("Username", user.TenND);
                    return RedirectToAction("Index", "DanhMucs", new { area = "Admin" });

                }
            }
            else
            {
                ViewBag.Message = "Mật khẩu không chính xác";
                return View();

            }
        }
        
        [HttpGet]
        public IActionResult TaiKhoan()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("DangNhap");
            }

            var taiKhoan = _applicationDbContext.TaiKhoan.SingleOrDefault(t => t.Id == userId.Value);
            return View(taiKhoan);
        }

        [HttpPost]
        public IActionResult TaiKhoan(TaiKhoan model)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("DangNhap");
            }

            var taiKhoan = _applicationDbContext.TaiKhoan.SingleOrDefault(t => t.Id == userId.Value);
            if (taiKhoan != null)
            {
                taiKhoan.TenND = model.TenND;
                taiKhoan.Email = model.Email;
                taiKhoan.MatKhau = model.MatKhau;
                taiKhoan.Diachi = model.Diachi;
                taiKhoan.SDT = model.SDT;
                taiKhoan.GioiTinh = model.GioiTinh;

                _applicationDbContext.SaveChanges();

                // Cập nhật lại thông tin trong session
                HttpContext.Session.SetString("Username", taiKhoan.TenND);

                ViewBag.Message = "Cập nhật thông tin thành công.";
            }
            return View(taiKhoan);
        }
        public IActionResult Dangky()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Username");
            return RedirectToAction("DangNhap");
        }

        [Route("Home/Ban")]
        [Route("Home/Ban/{id}")]
        public IActionResult Ban(int id)
        {
            var sanpham = _applicationDbContext.DanhMuc
                .Include(s => s.SanPham)
                .FirstOrDefault(s=>s.Id == id);
            return View(sanpham);
        }
        [Route("Home/ChiTiet")]
        [Route("Home/ChiTiet/{id}")]
        public IActionResult ChiTiet(int id)
        {
            var sanpham = _applicationDbContext.SanPham
                .Include(s => s.DanhMuc)
                .FirstOrDefault(s => s.Id == id);
            return View(sanpham);
        }
        public IActionResult GioiThieu()
        {
            return View();
        }

        public IActionResult DanhSachSanPham()
        {
            var sp = _applicationDbContext.DanhMuc.Include(dm => dm.SanPham).ToList();
            return View(sp);
        }
        public IActionResult TimKiem(string keyword)
        {
            // Xử lý từ khóa tìm kiếm và truy vấn cơ sở dữ liệu
            var sanPhams = _applicationDbContext.SanPham
                .Where(s => s.Name.Contains(keyword)) // Tìm kiếm theo tên sản phẩm, bạn có thể thay đổi điều kiện tìm kiếm tùy thuộc vào yêu cầu của bạn
                .ToList();

            return View(sanPhams);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
