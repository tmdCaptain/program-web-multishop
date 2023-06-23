using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multi_Shop.Models;

namespace Multi_Shop.Areas.Admin.Controllers
{
    public class GeneralController : Controller
    {
        // GET: Admin/General

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        
    }   

}