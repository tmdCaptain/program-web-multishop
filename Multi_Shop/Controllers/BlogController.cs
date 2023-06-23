using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multi_Shop.Models;

namespace Multi_Shop.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Add()
        {
            List<KhachHang> l = new MultiShopOnlineEntities().KhachHangs.ToList<KhachHang>();
            ViewData["listBlog"] = l;
            return View("Index");
        }

        [HttpPost]

        public ActionResult Index(KhachHang b)
        {
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();
            // Add Type Of Products to Data Model
            db.KhachHangs.Add(b);
            db.SaveChanges();
            ViewData["listBlog"] = db.KhachHangs.ToList<KhachHang>();
            return View();
        }

        [HttpPost]
        public ActionResult ComentArticle(CommentArticle b)
        {
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();
            // Add Type Of Products to Data Model
            db.CommentArticles.Add(b);
            db.SaveChanges();
            ViewData["listCommentProduct"] = db.CommentArticles.ToList<CommentArticle>();
            return RedirectToAction("Index");
        }
    }
}