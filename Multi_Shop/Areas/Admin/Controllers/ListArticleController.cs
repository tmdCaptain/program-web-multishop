using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multi_Shop.Models;

namespace Multi_Shop.Areas.Admin.Controllers
{
    public class ListArticleController : Controller
    {
        // GET: Admin/ListArticle

        // Static collection 
        private static MultiShopOnlineEntities  db = new MultiShopOnlineEntities();
        private static bool daDuyet;
        
        [HttpGet]

        public ActionResult Index(string IsActive)
        {
            daDuyet = IsActive.Equals("1");
            UpDateData();
            return View();
        }

        [HttpPost]
    
        public ActionResult Delete(string maBaiViet)
        {
            BaiViet x = db.BaiViets.Find(maBaiViet);
            db.BaiViets.Remove(x);
            db.SaveChanges();
            UpDateData();
            return View("Index");
        }


        [HttpPost]
        public ActionResult Active(string maBaiViet)
        {
            BaiViet x = db.BaiViets.Find(maBaiViet);
            x.daDuyet = !daDuyet;
            db.SaveChanges();
            UpDateData();
            return View("Index");
        }

        private void UpDateData()
        {
            List<BaiViet> l = db.BaiViets.Where(x => x.daDuyet == daDuyet).ToList<BaiViet>();
            ViewData["ListArticle"] = l;
            ViewBag.button = daDuyet ? "Không hiện thị" : "Kích hoạt";
        }
    }

}