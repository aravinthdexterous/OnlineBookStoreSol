using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBookStore.Models;
using System.IO;

namespace OnlineBookStore.Controllers
{
    public class WishListController : Controller
    {
        OnlineBookStoreDBEntities db = new OnlineBookStoreDBEntities();
        public ActionResult CartItems()
        {
            return View();
        }
           
    }
}