using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalAssignment.DbContent;
using FinalAssignment.Models;

namespace FinalAssignment.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            CMSdbcontent cmscontent = new CMSdbcontent();
            return View(cmscontent.Products.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products product)
        {
            CMSdbcontent cmscontent = new CMSdbcontent();
            cmscontent.Products.Add(product);
            cmscontent.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var cmscontent = new CMSdbcontent();
            if (id < 2)
            {
                return RedirectToAction("Index", new { id = 1 });
            }
            return View(cmscontent.Products.First(x => x.id == id));
        }

        public ActionResult Delete(int id)
        {
            var cmscontent = new CMSdbcontent();
            var empExists = cmscontent.Products.Any(x => x.id == id);
            if (empExists)
            {
                cmscontent.Products.Remove(cmscontent.Products.First(x => x.id == id));
                cmscontent.SaveChanges();
                return RedirectToAction("Index", new { message = "Product was deleted successfuly." });
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cmscontent = new CMSdbcontent();
            var empExists = cmscontent.Products.Any(x => x.id == id);
            if (!empExists)
            {
                return RedirectToAction("Index");
            }
            return View(cmscontent.Products.First(x => x.id == id));
        }
        [HttpPost]
        public ActionResult Edit(Products product)
        {
            var cmscontent = new CMSdbcontent();
            cmscontent.Entry(product).State = System.Data.Entity.EntityState.Modified;
            cmscontent.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Cart()
        {
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult AddtoCart(string name, string price)
        {
            Session["CartItemName"] = name;
            Session["CartItemPrice"] = price;

            return RedirectToAction("Index", "Cart");
        }

        public ActionResult ClearCart()
        {

            Session["CartItemName"] = null;
            Session["CartItemPrice"] = null;

            return RedirectToAction("Index", "Cart");
        }
    }
}