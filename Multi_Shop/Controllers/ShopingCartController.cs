using Multi_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Shop.Controllers
{
    public class ShopingCartController : Controller
    {
        // GET: ShopingCart
        [HttpGet]
        public ActionResult Index()
        {
            CartShop gh = Session["GioHang"] as CartShop;
            // Thêm sản phẩm vừa chọn 
            ViewData["Cart"] = gh;
            // Cập nhật lại giỏ hàng vào trong Sesstion
            return View("Index");
        }

        [HttpPost]
        public ActionResult Increase(string maSPA)
        {

            CartShop gh = Session["GioHang"] as CartShop;
            gh.addItem(maSPA);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Decrease(string maSPD)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.decrease(maSPD);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveItem(string maSPR)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.deleteItem(maSPR);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
    }
}