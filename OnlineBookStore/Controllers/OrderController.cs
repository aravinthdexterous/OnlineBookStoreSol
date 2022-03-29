using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBookStore.Models;

namespace OnlineBookStore.Controllers
{
    public class OrderController : Controller
    {
        OnlineBookStoreDBEntities obj = new OnlineBookStoreDBEntities();
        [HttpGet]
        public ActionResult Shippingdetails(int id)
        {
            if(obj.Accounts.Any(x => x.UserID == id))
            {
                return View(obj.Accounts.Where(x => x.UserID == id).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult Shippingdetails(int UserID, Account userdata)
        {
            var data = obj.Accounts.Where(x => x.UserID == userdata.UserID).FirstOrDefault();
            return View();
        }
    }
}