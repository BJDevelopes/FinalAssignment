using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalAssignment.DbContent;
using FinalAssignment.Models;
namespace FinalAssignment.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            CMSdbcontent context = new CMSdbcontent();
            return View(context.Products.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.message = "";
            return View();
        }
        [HttpPost]
        public ActionResult Create(Products product)
        {
            ViewBag.message = "";
            if (ModelState.IsValid)
            {
                var context = new CMSdbcontent();
                context.Products.Add(product);
                context.SaveChanges();
                ModelState.Clear();
                return View(new Products());
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var context = new CMSdbcontent();
            return View(context.Products.First(x => x.id == id));
        }
        public ActionResult Delete(int id)
        {
            var context = new CMSdbcontent();
            var productExists = context.Products.Any(x => x.id == id);
            if (productExists)
            {
                context.Products.Remove(context.Products.First(x => x.id == id));
                context.SaveChanges();
                return RedirectToAction("Index", new { message = "Product was deleted successfuly." });
            }
            return View();
        }
    }
}