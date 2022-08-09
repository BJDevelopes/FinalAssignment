using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalAssignment.DbContent;
using FinalAssignment.Models;

namespace FinalAssignment.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            //creates an object of our database context class
            CMSdbcontent cmscontent = new CMSdbcontent();

            //gets values from the from entered by the user, using form collection
            string inputUsername = formCollection["username"];
            var inputPassword = formCollection["password"];

            //Querys the database and gets the password associated with the entered username.
            string dbPassword = cmscontent.Database.SqlQuery<string>("Select password from Users where username='" + inputUsername +"'").FirstOrDefault();
           
            if (inputPassword == dbPassword)
            {
                return RedirectToAction("Index", "");
            }
            else
            {
                //Do Nothing for now
                return View();
            }    
 
        }


    }
}