using Multi_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Shop.Areas.Admin.Controllers
{
    public class ListProductsController : Controller
    {
        // GET: Admin/ListProducts
        private static MultiShopOnlineEntities db = new MultiShopOnlineEntities();
        private static bool daDuyet;

        [HttpGet]

        public ActionResult Index(string IsActive)
        {
            daDuyet = IsActive.Equals("1");
            UpDateData();
            return View();
        }

        [HttpPost]

        public ActionResult Delete(string maSP)
        {
            SanPham x = db.SanPhams.Find(maSP);
            db.SanPhams.Remove(x);
            db.SaveChanges();
            UpDateData();
            return View("Index");
        }


        [HttpPost]
        public ActionResult Active(string maSP)
        {
            SanPham x = db.SanPhams.Find(maSP);
            x.daDuyet = !daDuyet;
            db.SaveChanges();
            UpDateData();
            return View("Index");
        }

        private void UpDateData()
        {
            List<SanPham> l = db.SanPhams.Where(x => x.daDuyet == daDuyet).ToList<SanPham>();
            ViewData["ListProducts"] = l;
            ViewBag.button = daDuyet ? "Không hiển thị" : "Kích hoạt";
        }
    }
}