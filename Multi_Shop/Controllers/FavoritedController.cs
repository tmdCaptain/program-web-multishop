using Multi_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Shop.Controllers
{
    public class FavoritedController : Controller
    {
        // GET: Favorited
        public ActionResult Index()
        {
            FavoritedProducts yt = Session["YeuThich"] as FavoritedProducts;
            // Thêm sản phẩm vừa chọn 
            ViewData["Heart"] = yt;
            // Cập nhật lại sản phẩm được tim vào trong Sesstion
            return View();
        }
    }
}