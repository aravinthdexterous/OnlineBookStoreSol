using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using OnlineBookStore.Models;
using System.IO;
using System.Data.Entity;

namespace OnlineBookStore.Controllers
{
    public class ProductController : Controller
    {
        OnlineBookStoreDBEntities dbobj = new OnlineBookStoreDBEntities();
        public ActionResult EditProduct(int id)
        {
            return View(dbobj.Products.Where(x => x.BookID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditProduct(int BookID, Product model)
        {
            string fileName1 = Path.GetFileNameWithoutExtension(model.ImageFile1.FileName);
            string extension1 = Path.GetExtension(model.ImageFile1.FileName);
            fileName1 = fileName1 + DateTime.Now.ToString("-yyyy-MM-dd-hh-mm-ss") + extension1;
            model.Image_1 = "~/Image/" + fileName1;
            fileName1 = Path.Combine(Server.MapPath("~/Image/"), fileName1);
            model.ImageFile1.SaveAs(fileName1);

            string fileName2 = Path.GetFileNameWithoutExtension(model.ImageFile2.FileName);
            string extension2 = Path.GetExtension(model.ImageFile2.FileName);
            fileName2 = fileName2 + DateTime.Now.ToString("-yyyy-MM-dd-hh-mm-ss") + extension2;
            model.Image_2 = "~/Image/" + fileName2;
            fileName2 = Path.Combine(Server.MapPath("~/Image/"), fileName2);
            model.ImageFile2.SaveAs(fileName2);

            string fileName3 = Path.GetFileNameWithoutExtension(model.ImageFile3.FileName);
            string extension3 = Path.GetExtension(model.ImageFile3.FileName);
            fileName3 = fileName3 + DateTime.Now.ToString("-yyyy-MM-dd-hh-mm-ss") + extension3;
            model.Image_3 = "~/Image/" + fileName3;
            fileName3 = Path.Combine(Server.MapPath("~/Image/"), fileName3);
            model.ImageFile3.SaveAs(fileName3);

            string fileName4 = Path.GetFileNameWithoutExtension(model.ImageFile4.FileName);
            string extension4 = Path.GetExtension(model.ImageFile4.FileName);
            fileName4 = fileName4 + DateTime.Now.ToString("-yyyy-MM-dd-hh-mm-ss") + extension4;
            model.Image_4 = "~/Image/" + fileName4;
            fileName4 = Path.Combine(Server.MapPath("~/Image/"), fileName4);
            model.ImageFile4.SaveAs(fileName4);

            var data = dbobj.Products.Where(x => x.BookID == model.BookID).FirstOrDefault();
            if(data != null)
            {
                data.BookName = model.BookName;
                data.Author = model.Author;
                data.Image_1 = model.Image_1;
                data.Image_2 = model.Image_2;
                data.Image_3 = model.Image_3;
                data.Image_4 = model.Image_4;
                data.Price = model.Price;
                data.PrintLength = model.PrintLength;
                data.Language = model.Language;
                data.PublicationDate = model.PublicationDate;
                data.Publisher = model.Publisher;
                data.Description = model.Description;

                dbobj.SaveChanges();
            }
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            string fileName1 = Path.GetFileNameWithoutExtension(model.ImageFile1.FileName);
            string extension1 = Path.GetExtension(model.ImageFile1.FileName);
            fileName1 = fileName1 + DateTime.Now.ToString("-yyyy-MM-dd-hh-mm-ss") + extension1;
            model.Image_1 = "~/Image/" + fileName1;
            fileName1 = Path.Combine(Server.MapPath("~/Image/"), fileName1);
            model.ImageFile1.SaveAs(fileName1);

            string fileName2 = Path.GetFileNameWithoutExtension(model.ImageFile2.FileName);
            string extension2 = Path.GetExtension(model.ImageFile2.FileName);
            fileName2 = fileName2 + DateTime.Now.ToString("-yyyy-MM-dd-hh-mm-ss") + extension2;
            model.Image_2 = "~/Image/" + fileName2;
            fileName2 = Path.Combine(Server.MapPath("~/Image/"), fileName2);
            model.ImageFile2.SaveAs(fileName2);

            string fileName3 = Path.GetFileNameWithoutExtension(model.ImageFile3.FileName);
            string extension3 = Path.GetExtension(model.ImageFile3.FileName);
            fileName3 = fileName3 + DateTime.Now.ToString("-yyyy-MM-dd-hh-mm-ss") + extension3;
            model.Image_3 = "~/Image/" + fileName3;
            fileName3 = Path.Combine(Server.MapPath("~/Image/"), fileName3);
            model.ImageFile3.SaveAs(fileName3);

            string fileName4 = Path.GetFileNameWithoutExtension(model.ImageFile4.FileName);
            string extension4 = Path.GetExtension(model.ImageFile4.FileName);
            fileName4 = fileName4 + DateTime.Now.ToString("-yyyy-MM-dd-hh-mm-ss") + extension4;
            model.Image_4 = "~/Image/" + fileName4;
            fileName4 = Path.Combine(Server.MapPath("~/Image/"), fileName4);
            model.ImageFile4.SaveAs(fileName4);

            using (OnlineBookStoreDBEntities dbobj = new OnlineBookStoreDBEntities())
            {
                if(model.BookID == 0)
                {
                    dbobj.Products.Add(model);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Entry(model).State = EntityState.Modified; 
                }
            }
            ModelState.Clear();
            return View("AddProduct");
        }

        public ActionResult ProductList()
        {
            var result = dbobj.Products.ToList();
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            var result = dbobj.Products.Where(x => x.BookID == id).First();
            dbobj.Products.Remove(result);
            dbobj.SaveChanges();

            var list = dbobj.Products.ToList();

            return View("ProductList", list);
        }
        public ActionResult ProductInfo(int id)
        {
            Product data = dbobj.Products.Single(x => x.BookID == id);
            return View(data);
        }
    }
}