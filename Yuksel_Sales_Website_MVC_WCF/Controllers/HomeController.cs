using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yuksel_Sales_Website_MVC_WCF.Classes;
using Yuksel_Sales_Website_MVC_WCF.Models;

namespace Yuksel_Sales_Website_MVC_WCF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ControlPanel()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ProductPageAjax(int Page, int PageSize)
        {
            ProductPage p = new ProductPage();
            return Json(p.Paging(Page, PageSize));
        }

        [HttpPost]
        public JsonResult CategoryPageAjax(int Page, int PageSize)
        {
            CategoryPage p = new CategoryPage();

            return Json(p.Paging(Page, PageSize));
        }
    }
}