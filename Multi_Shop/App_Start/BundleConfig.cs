using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;


namespace Multi_Shop.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundle)
        {
            //Add style bundle css
            bundle.Add(new StyleBundle("~/bundle/css").Include("~/Content/lib/animate/animate.min.css",
                "~/Content/lib/owlcarousel/assets/owl.carousel.min.css",
                "~/Content/css/style.css",
                "~/Content/Site.css"));
            //Add Style bundle js

            bundle.Add(new ScriptBundle("~/bundle/js").Include(
                "~/Content/lib/easing/easing.min.js",
                "~/Content/lib/owlcarousel/owl.carousel.min.js",
                "~/Content/mail/jqBootstrapValidation.min.js",
                "~/Content/mail/contact.js",
                "~/Content/js/main.js"));
        }
    }
}