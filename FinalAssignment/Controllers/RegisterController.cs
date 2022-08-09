using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalAssignment.DbContent;
using FinalAssignment.Models;

namespace FinalAssignment.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Users user)
        {
            CMSdbcontent cmscontent = new CMSdbcontent();
            cmscontent.Users.Add(user);
            cmscontent.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}