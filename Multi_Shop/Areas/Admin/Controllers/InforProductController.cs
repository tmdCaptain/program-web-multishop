using Multi_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Shop.Areas.Admin.Controllers
{
    public class InforProductController : Controller
    {
        // GET: Admin/InforProduct
            public ActionResult Index(string maSP)
            {
                MultiShopOnlineEntities db = new MultiShopOnlineEntities();
                SanPham x = db.SanPhams.Where(y => y.maSP.Equals(maSP)).First<SanPham>();
                ViewData["ThongtinSp"] = x;
                return View();
            }
    }
}