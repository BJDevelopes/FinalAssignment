using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalAssignment.DbContent;
using FinalAssignment.Models;

namespace FinalAssignment.Controllers
{
    public class OrdersController : Controller
    {
        private CMSdbcontent db = new CMSdbcontent();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,userID,productID,total")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,userID,productID,total")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateOrder()
        {
            if(Session["CartItemName"] != null || Session["CartItemName"] != null || Session["Total"] != null)
            {
                //creates an object of our database context class
                CMSdbcontent cmscontent = new CMSdbcontent();
                if ((Session["CartItemName"].ToString() != "Empty") && (Session["CartItemPrice"].ToString() != "0.00") && ( Session["Total"].ToString() != "0.00"))
                {
                    var name = Session["CartItemName"].ToString();
                    var price = Session["CartItemPrice"].ToString();
                    var total = Session["Total"].ToString();
                    var user = Request.Cookies["user"].Value.ToString();
                    var quantity = "1";  // for now users can only buy 1 at a time;
                    //Querys the database and gets the password associated with the entered username.
                    int userid = cmscontent.Database.SqlQuery<int>("Select id from Users where username='" + user + "'").FirstOrDefault();
                    int productid = cmscontent.Database.SqlQuery<int>("Select id from Products where name='" + name + "'").FirstOrDefault();
                    int id = cmscontent.Database.SqlQuery<int>("Select Max(id) +1 from Orders").FirstOrDefault();
                    System.Diagnostics.Debug.WriteLine("User ID Found | Value - " + userid.ToString());
                    System.Diagnostics.Debug.WriteLine("Product ID Found | Value - " + productid.ToString());

                    cmscontent.Orders.Add(new Orders
                        {
                            id = id,
                            userID = userid,
                            productID = productid,
                            quantity = quantity,
                            total = total
                        });
                    cmscontent.SaveChanges();

                    TempData["Success"] = "Order Successfully Submitted!";
                }
                else if ((Session["CartItemName"].ToString() != "Empty") && (Session["CartItemPrice"].ToString() != "0.00") && (Session["Total"].ToString() != "0"))
                {
                    var name = Session["CartItemName"].ToString();
                    var price = Session["CartItemPrice"].ToString();
                    var total = Session["Total"].ToString();
                    var user = Request.Cookies["user"].Value.ToString();
                    var quantity = "1";  // for now users can only buy 1 at a time;


                    TempData["Success"] = "Order Successfully Submitted!";
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Item Data Not Found");
                    TempData["Empty"] = "Your Cart is Empty, please add something before submitting.";
                    //return RedirectToAction("Index", "Cart");
                }
            }

            return RedirectToAction("Index", "Cart");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
