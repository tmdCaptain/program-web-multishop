using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Shop.Areas.Admin.Controllers
{
    public class ListCustomersController : Controller
    {
        // GET: Admin/ListCustomers
        public ActionResult Index()
        {
            return View();
        }
    }
}