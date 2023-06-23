using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Multi_Shop.Models;

namespace Multi_Shop.Areas.Admin.Models
{
    public class Dungchung
    {

        // Read infor Account login
        public static TaiKhoan getAccount()
        {
            TaiKhoan kq = new TaiKhoan();
            kq = HttpContext.Current.Session["TtDangNhap"] as TaiKhoan;
            return kq;
        }

        // Read Account name

        public static string getNameAccount()
        {
            return getAccount().taiKhoan1;   
        }
    }
}