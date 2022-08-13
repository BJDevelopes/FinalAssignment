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
            HttpCookie saveLogin = new HttpCookie("saveLogin");
            saveLogin.Expires = DateTime.Now.AddYears(1);

            //gets values from the from entered by the user, using form collection
            string inputUsername = formCollection["username"];
            var inputPassword = formCollection["password"];

            //Querys the database and gets the password associated with the entered username.
            string dbPassword = cmscontent.Database.SqlQuery<string>("Select password from Users where username='" + inputUsername + "'").FirstOrDefault();
            string dbAdmin = cmscontent.Database.SqlQuery<string>("Select isadmin from Users where username='" + inputUsername + "'").FirstOrDefault();
            
            Session["admin"] = dbAdmin;
            string adminstring = "trueAdmin";
            string userstring = "true";

            //Decides what view the user will see depending if there are an admin or not.
            try
            {
                //Checks checks if the cookie and the inputPassowrd stirng are empty
                if (Request.Cookies["saveLogin"] != null && String.IsNullOrEmpty(inputPassword))
                {
                    //if the cookies value is == to userstyirng just loads the normal user view 
                    if (Request.Cookies["saveLogin"].Value.ToString() == userstring.ToString())
                    {
                        Session["admin"] = "false";
                        return RedirectToAction("Index", "");
                    }
                    //if the cookie is == to admin string then sets it to the admin view.
                    else if (Request.Cookies["saveLogin"].Value.ToString() == adminstring.ToString())
                    {
                        Session["admin"] = "true";
                        return RedirectToAction("Index", "");
                    }
                    else
                    {
                        return View();
                    }
                }
                //if there is not cookie, checks the input from the user
                else if (inputPassword == dbPassword)
                {
                    //sets the cookie value for the next login
                    if (Session["admin"].ToString() == "true")
                    {
                        saveLogin.Value = adminstring;
                    }
                    else
                    {
                        saveLogin.Value = userstring;
                    }
                    Response.Cookies.Add(saveLogin);
                    return RedirectToAction("Index", "");
                }
                else
                {
                    return View();
              
                }
            }
            //catches exception if there is not cookie present.
            catch (Exception)
            {
                if (inputPassword == dbPassword)
                {
                    saveLogin.Value = userstring;
                    Response.Cookies.Add(saveLogin);
                    return RedirectToAction("Index", "");
                }
                else
                {

                    return View();
                }
            }
        }
        public ActionResult DeleteCookie()
        {
            //layouts call this action to delete the saveLogin cookie when a user signs out.
            Response.Cookies["saveLogin"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Create", "Login");
        }


    }
}