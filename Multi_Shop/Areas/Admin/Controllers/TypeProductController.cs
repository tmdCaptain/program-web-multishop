using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multi_Shop.Models;

namespace Multi_Shop.Areas.Admin.Controllers
{
    public class TypeProductController : Controller
    {
        private static bool isInsert = false;

        // GET: Admin/TypeProduct
        [HttpGet]
        public ActionResult Index()
        {
            List<LoaiSP> l = new MultiShopOnlineEntities().LoaiSPs.ToList<LoaiSP>();
            ViewData["listProducts"] = l;
            return View();
        }

        [HttpPost]

        public ActionResult Index(LoaiSP b)
        {
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();
            // Add Type Of Products to Data Model

            if (!isInsert)
            
                db.LoaiSPs.Add(b);
            else
            {
                LoaiSP x = db.LoaiSPs.Find(b.maLoai);
                x.tenLoai = b.tenLoai;
                x.ghiChu = b.ghiChu;
                isInsert = false;
            }
            // Save Type Of Products to data
            db.SaveChanges();
            // Update list to View

            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["listProducts"] = db.LoaiSPs.ToList<LoaiSP>(); 
            return View();
        }

        [HttpPost]

        public ActionResult Delete(string maLoai)
        {

            MultiShopOnlineEntities db = new MultiShopOnlineEntities();


            int ma = int.Parse(maLoai);

            // Find maLoai  object in data model 
            LoaiSP p = db.LoaiSPs.Find(ma);

            // Delete loaiSP object in datamodel
            db.LoaiSPs.Remove(p);

            // Update list to datamodel
            db.SaveChanges();

            // Update list to View
            ViewData["listProducts"] = db.LoaiSPs.ToList<LoaiSP>();
            return View("Index");
        }

        [HttpPost]

        public ActionResult Insert(string maLoaiS)
        {
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();
            int ma = int.Parse(maLoaiS);
            LoaiSP p = db.LoaiSPs.Find(ma);
            isInsert = true;
            // Update list to View
            ViewData["listProducts"] = db.LoaiSPs.ToList<LoaiSP>();
            return View("Index" , p);
        }
    }
}