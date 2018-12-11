using CS481.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS481.Controllers
{
    public class LoginController : Controller
    {
        db5a2eb9b6e7614a45b937a98b012d7edbEntities db = new db5a2eb9b6e7614a45b937a98b012d7edbEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Authorize(User user)
        {
            using (db5a2eb9b6e7614a45b937a98b012d7edbEntities db = new db5a2eb9b6e7614a45b937a98b012d7edbEntities())
            {
                var userDetails = db.Users.Where(x => x.email == user.email && x.password == user.password).FirstOrDefault();
                if (userDetails == null)
                {
                    user.LoginErrorMessage = "Incorrect email or password.";
                    return View("Index", user);
                }

                else
                {
                    Session["userId"] = userDetails.userId;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}