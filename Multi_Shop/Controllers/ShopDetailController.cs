using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multi_Shop.Models;

namespace Multi_Shop.Controllers
{
    public class ShopDetailController : Controller
    {
        // GET: ShopDetail
        public ActionResult Index(string maSP)
        {
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();
            SanPham x = db.SanPhams.Where(y => y.maSP.Equals(maSP)).First<SanPham>();
            ViewData["ThongtinSp"] = x;
            return View();
        }

    }
}