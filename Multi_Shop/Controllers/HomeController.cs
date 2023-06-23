using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multi_Shop.Models;
namespace Multi_Shop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        // Lấy giỏ hàng

        public ActionResult AddtoCart(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            // Thêm sản phẩm vừa chọn 
            gh.addItem(maSP);

            // Cập nhật lại giỏ hàng vào trong Sesstion
            Session["GioHang"] = gh;
            return View("Index");
        }

        public ActionResult AddtoHeart(string maSP)
        {
            FavoritedProducts yt = Session["YeuThich"] as FavoritedProducts;
            // Thêm sản phẩm vừa chọn 
            yt.addItem(maSP);

            // Cập nhật lại giỏ hàng vào trong Sesstion
            Session["YeuThich"] = yt;
            return View("Index");
        }

        public ActionResult Add()
        {
            List<Comment> l = new MultiShopOnlineEntities().Comments.ToList<Comment>();
            ViewData["listCommentProduct"] = l;
            return View("Index");
        }

        [HttpPost]

        public ActionResult Comment(Comment b)
        {
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();
            // Add Type Of Products to Data Model
            db.Comments.Add(b);
            db.SaveChanges();
            ViewData["listComment"] = db.Comments.ToList<Comment>();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(CommentArticle b)
        {
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();
            // Add Type Of Products to Data Model
            db.CommentArticles.Add(b);
            db.SaveChanges();
            ViewData["listCommentProduct"] = db.CommentArticles.ToList<CommentArticle>();
            return View();
        }

    }
}