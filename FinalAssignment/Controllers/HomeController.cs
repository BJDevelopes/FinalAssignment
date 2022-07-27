using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products()
        {
            ViewBag.Message = "View all products page.";
            return View();
        }


        public ActionResult Register()
        {
            ViewBag.Message = "Register Page.";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Administrator Panel.";

            return View("~/Views/Home/Admin/Index.cshtml");
        }

        public ActionResult AProducts()
        {
            ViewBag.Message = "Products Administrator Panel.";

            return View("~/Views/Home/Admin/AProducts.cshtml");
        }

        public ActionResult Users()
        {
            ViewBag.Message = "Users Administrator Panel.";

            return View("~/Views/Home/Admin/Users.cshtml");
        }

        public ActionResult SiteConfig()
        {
            ViewBag.Message = "Site Configuration Administrator Panel.";

            return View("~/Views/Home/Admin/SiteConfig.cshtml");
        }
    }
}