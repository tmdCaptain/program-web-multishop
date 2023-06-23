using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multi_Shop.Models;
namespace Multi_Shop.Controllers
{
    public class BlogDetailController : Controller
    {
        [HttpGet]
        // GET: BlogDetail
        public ActionResult Index(string maBV)
        {
            MultiShopOnlineEntities db = new MultiShopOnlineEntities();
            BaiViet x = db.BaiViets.Where(y => y.maBV.Equals(maBV)|| maBV==null).First<BaiViet>();
            ViewData["ThongtinBV"] = x;
            
            return View();
        }

        public ActionResult Index()
        {
            List<KhachHang> l = new MultiShopOnlineEntities().KhachHangs.ToList<KhachHang>();
            ViewData["listBlog"] = l;
            return View();
        }
    }
}