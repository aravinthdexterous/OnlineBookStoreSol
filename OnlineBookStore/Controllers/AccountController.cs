using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using OnlineBookStore.Models;

namespace OnlineBookStore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult SignUp(int id = 0)
        {
            Account register = new Account();
            return View(register);
        }
        [HttpPost]
        public ActionResult SignUp(Account register)
        {
            using (OnlineBookStoreDBEntities db = new OnlineBookStoreDBEntities())
            {
                if (db.Accounts.Any(x => x.MailID == register.MailID))
                {
                    ViewBag.DuplicateMessage = "MailID already exist";
                    return View("SignUp", register);
                }
                else
                {
                    db.Accounts.Add(register);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Registration Successful";
                    return View("SignUp", new Account());
                }
                
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account login)
        {
            using (OnlineBookStoreDBEntities db = new OnlineBookStoreDBEntities())
            {
                var user = db.Accounts.Where(x => x.MailID == login.MailID && x.Password == login.Password).FirstOrDefault();
                if (user == null)
                {
                    login.LoginErrorMessage = "Wrong Username or Password";
                    return View("Login", login);
                }
                else
                {
                    Session["UserID"] = user.UserID;
                    Session["MailID"] = user.MailID;
                    Session["Username"] = user.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult Logout()
        {
            Session["MailID"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}