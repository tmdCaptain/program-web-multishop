using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multi_Shop.Models;

namespace Multi_Shop.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(string Acc, string Pass)

        {
            string mk = Security.encryptSHA256(Pass);
            TaiKhoan inforLogin = new MultiShopOnlineEntities()
                .TaiKhoans.Where(a => a.taiKhoan1.Equals(Acc.ToLower().Trim()) && a.matKhau.Equals(mk))
                .First<TaiKhoan>();

            bool isAuthentic = inforLogin !=null && inforLogin.taiKhoan1.Equals(Acc.ToLower().Trim()) && inforLogin.matKhau.Equals(mk);

            if (isAuthentic) {

                Session["TtDangNhap"] = inforLogin;
                return RedirectToAction("Index", "General", new { Area = "Admin" });
            }

            return View();
            
        }

        
    }
}