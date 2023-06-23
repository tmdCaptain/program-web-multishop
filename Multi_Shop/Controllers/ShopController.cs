using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multi_Shop.Models;
namespace Multi_Shop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index(String Search)

        {
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();
            return View(db.SanPhams.Where(m => m.tenSP.Contains(Search) || Search == null && m.daDuyet == true));
        }

        // Lấy giỏ hàng

        public ActionResult AddtoCartShop(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            // Thêm sản phẩm vừa chọn 
            gh.addItem(maSP);

            // Cập nhật lại giỏ hàng vào trong Sesstion
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }

        public ActionResult AddtoHeart(string maSP)
        {
            FavoritedProducts yt = Session["YeuThich"] as FavoritedProducts;
            // Thêm sản phẩm vừa chọn 
            yt.addItem(maSP);

            // Cập nhật lại giỏ hàng vào trong Sesstion
            Session["YeuThich"] = yt;
            return RedirectToAction("Index");
        }

        [HttpPost]

        public ActionResult Comment(Comment b)
        {
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();
            // Add Type Of Products to Data Model
            db.Comments.Add(b);
            db.SaveChanges();
            ViewData["listComment"] = db.Comments.ToList<Comment>();
            return RedirectToAction("Index");
        }

        




    }
}