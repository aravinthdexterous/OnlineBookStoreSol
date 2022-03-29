using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBookStore.Models;

namespace OnlineBookStore.Controllers
{
    public class AdminController : Controller
    {
        OnlineBookStoreDBEntities db = new OnlineBookStoreDBEntities();
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin login)
        {
            var user = db.Admins.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
            if (user != null)
            {
                Session["Admin-Username"] = user.UserName;
                return RedirectToAction("ProductList", "Product");
            }
            else
            {
                login.LoginErrorMessage = "Wrong Username or Password";
                return View("AdminLogin", login);
            }
        }
        public ActionResult Logout()
        {
            Session["Admin-Username"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}