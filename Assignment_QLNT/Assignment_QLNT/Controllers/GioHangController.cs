using Asm1.DATA;
using Asm1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asm1.Controllers
{
    public class GioHangController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public GioHangController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult GioHang()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("DangNhap","Home");
            }

            var cartItems = _applicationDbContext.GioHang
                .Where(c => c.TaiKhoan.Id == userId.Value)
                .Include(c => c.SanPham) // Include product details
                .ToList();

            return View(cartItems);
        }
        public IActionResult Index()
        {
            return View();
        }
        
        //[HttpPost]
        //public async Task<IActionResult> AddToCart(int productId, int quantity)
        //{
        //    if(User.Identity.IsAuthenticated)
        //    {
        //        var userId = GetUserId();
        //        var existingCartItem = _applicationDbContext.GioHang
        //            .FirstOrDefault(g => g.IdTaiKhoan == userId && g.IdSanPham == productId);

        //        if (existingCartItem != null)
        //        {
        //            existingCartItem.SoLuong += quantity;
        //        }
        //        else
        //        {
        //            var newCartItem = new GioHang
        //            {
        //                IdTaiKhoan = userId,
        //                IdSanPham = productId,
        //                SoLuong = quantity
        //            };
        //            _applicationDbContext.GioHang.Add(newCartItem);
        //        }
        //        _applicationDbContext.SaveChanges();
        //    }
        //    else
        //    {
        //        // Người dùng chưa đăng nhập, thêm vào session
        //        var cart = GetCartItemsFromSession();
        //        var cartItem = cart.FirstOrDefault(c => c.IdSanPham == productId);

        //        if (cartItem != null)
        //        {
        //            cartItem.SoLuong += quantity;
        //        }
        //        else
        //        {
        //            cart.Add(new GioHang { IdSanPham = productId, SoLuong = quantity });
        //        }

        //        SaveCartItemsToSession(cart);
        //    }
        //    return RedirectToAction("Index", "GioHang");
        //}
        //private List<GioHang> GetCartItemsFromSession()
        //{
        //    //Lưu sản phẩm vào session khi chưa đăng nhập
        //    var sessionCart = HttpContext.Session.GetString("Cart");
        //    return sessionCart != null ? JsonConvert.DeserializeObject<List<GioHang>>(sessionCart) : new List<GioHang>();
        //}
        //private void SaveCartItemsToSession(List<GioHang> cartItems)
        //{
        //    HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));
        //}
        //private int GetUserId()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
        //        if (userIdClaim != null)
        //        {
        //            return int.Parse(userIdClaim.Value);
        //        }
        //    }
        //    throw new InvalidOperationException("Người dùng chưa đăng nhập hoặc không có thông tin UserId");
        //}
        //public async Task MoveSessionCartToDatabase()
        //{
        //    var userId = GetUserId();
        //    var cart = GetCartItemsFromSession();

        //    foreach (var item in cart)
        //    {
        //        var existingCartItem = _applicationDbContext.GioHang
        //            .FirstOrDefault(g => g.IdTaiKhoan == userId && g.IdSanPham == item.IdSanPham);

        //        if (existingCartItem != null)
        //        {
        //            existingCartItem.SoLuong += item.SoLuong;
        //        }
        //        else
        //        {
        //            var newCartItem = new GioHang
        //            {
        //                IdTaiKhoan = userId,
        //                IdSanPham = item.IdSanPham,
        //                SoLuong = item.SoLuong
        //            };
        //            _applicationDbContext.GioHang.Add(newCartItem);
        //        }
        //    }

        //    await _applicationDbContext.SaveChangesAsync();
        //    // Xóa giỏ hàng trong session
        //    HttpContext.Session.Remove("Cart");
        //}
    }
}
