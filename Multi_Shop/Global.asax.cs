using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using System.Web.Optimization;
using Multi_Shop.App_Start;
using Multi_Shop.Models;

namespace Multi_Shop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Register your bundle here
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //-- Aplications Object để chứa common
            Application["dungchung"] = new Common();
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["TtDangNhap"] = null;
            // Giỏ hàng đang trống
            Session["GioHang"] = new CartShop();
            Session["YeuThich"] = new FavoritedProducts();
        }
      
    }
}
