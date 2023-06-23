using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multi_Shop.Models;
using Multi_Shop.Areas.Admin.Models;
using System.IO;
namespace Multi_Shop.Areas.Admin.Controllers
{
    public class PostArticleController : Controller
    {
        // GET: Admin/PostArticle

        [HttpGet]
        public ActionResult Index() 
        {
            BaiViet x = new BaiViet();
            x.ngayDang = DateTime.Now;
            x.taiKhoan = Dungchung.getNameAccount();

            // Đưa đường dẫn hình ra ngoài hiển thị trên Image
            ViewBag.ddHinh = "/Content/img/giay-da-nam-sneako.jpg";
            return View(x);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(BaiViet x, HttpPostedFileBase hinhDD)
        {

            try
            {
                x.maBV = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                x.daDuyet = false;
                x.ngayDang = DateTime.Now;
                x.taiKhoan = Dungchung.getNameAccount();
                x.loaiTin = "Tin tuc";


                // Save img in folder
                if (hinhDD != null)
                {
                    string virPath = "/Content/img/";
                    string phyPath = Server.MapPath("~/" + virPath); //Xác định vị trí lưu hình

                    string ext = Path.GetExtension(hinhDD.FileName);
                    string tenFile = "HDD" + x.maBV + "." + ext;

                    hinhDD.SaveAs(phyPath + tenFile); // Lưu dựa vào đường dẫn vật lý
                    x.hinhDD = virPath + tenFile;     // Đường ảo theo domain
                                                      //x.hinhDD
                                                      // Cập nhật hình đại diện
                    ViewBag.ddHinh = x.hinhDD;
                }

                else
                    x.hinhDD = "";

                // Update Object
                MultiShopOnlineEntities db = new MultiShopOnlineEntities();
                db.BaiViets.Add(x);
                db.SaveChanges();
                return RedirectToAction("Index", "ListArticle", new { IsActive = 0 });
            }
            catch
            {

            }


            return View(x);
        }
    }
}