using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalAssignment.DbContent;
using FinalAssignment.Models;

namespace FinalAssignment.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        
        public ActionResult Index()
        {
            CMSdbcontent cmscontent = new CMSdbcontent();
            return View(cmscontent.Users.ToList());
        }

        /*
       [HttpPost]
        public ActionResult Create(Users user)
        {
            CMSdbcontent cmscontent = new CMSdbcontent();
            cmscontent.Users.Add(user);
            cmscontent.SaveChanges();

            return RedirectToAction("Index");
        }
        */
        [HttpGet]
        public ActionResult Create()
        {
           return View();
        }

        [HttpPost]
        public ActionResult Create(Users user)
        {
            if (ModelState.IsValid)
            {
                CMSdbcontent cmscontent = new CMSdbcontent();
                cmscontent.Users.Add(user);
                cmscontent.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var cmscontent = new CMSdbcontent();
            if (id < 2)
            {
                return RedirectToAction("Index", new { Id = 1 });
            }
            return View(cmscontent.Users.First(x => x.Id == id));
        }

        public ActionResult Delete(int id)
        {
            var cmscontent = new CMSdbcontent();
            var empExists = cmscontent.Users.Any(x => x.Id == id);
            if (empExists)
            {
                cmscontent.Users.Remove(cmscontent.Users.First(x => x.Id == id));
                cmscontent.SaveChanges();
                return RedirectToAction("Index", new { message = "Employee was deleted successfuly." });
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cmscontent = new CMSdbcontent();
            var empExists = cmscontent.Users.Any(x => x.Id == id);
            if (!empExists)
            {
                return RedirectToAction("Index");
            }
            return View(cmscontent.Users.First(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult Edit(Users user)
        {
            var cmscontent = new CMSdbcontent();
            cmscontent.Entry(user).State = System.Data.Entity.EntityState.Modified;
            cmscontent.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}