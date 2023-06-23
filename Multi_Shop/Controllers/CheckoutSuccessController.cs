using Multi_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Shop.Controllers
{
    public class CheckoutSuccessController : Controller
    {
        // GET: CheckoutSuccess
        [HttpGet]
        public ActionResult Index()
        {
            KhachHang x = new KhachHang();
            CartShop gh = Session["GioHang"] as CartShop;
            // Thêm sản phẩm vừa chọn 
            ViewData["Cart"] = gh;
            // Cập nhật lại giỏ hàng vào trong Sesstion
            return View(x);
        }
    }
}