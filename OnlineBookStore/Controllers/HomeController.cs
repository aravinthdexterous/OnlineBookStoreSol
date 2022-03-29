using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBookStore.Models;

namespace OnlineBookStore.Controllers
{
    public class HomeController : Controller
    {
        OnlineBookStoreDBEntities db = new OnlineBookStoreDBEntities();
        public ActionResult Index()
        {
            var result = db.Products.ToList();
            return View(result);
        }
    }
}