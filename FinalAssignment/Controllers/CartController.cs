using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalAssignment.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            if (Session["CartItemName"] != null)
            {
                System.Diagnostics.Debug.WriteLine("Item Name Found | Value - " + Session["CartItemName"].ToString());
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Item Name Not Found");
            }
            if (Session["CartItemPrice"] != null)
            {
                System.Diagnostics.Debug.WriteLine("Item Price Found | Value - " + Session["CartItemPrice"].ToString());
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Item Price Not Found");
            }

            return View();
        }

    }
}
