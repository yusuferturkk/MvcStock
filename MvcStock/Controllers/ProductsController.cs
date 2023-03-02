using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class ProductsController : Controller
    {
        
        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult Index()
        {
            var products = db.TblProduct.ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> values = (from i in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryID.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(TblProduct p1)
        {
            var category = db.TblCategory.Where(m => m.CategoryID == p1.TblCategory.CategoryID).FirstOrDefault();
            p1.TblCategory = category;
            db.TblProduct.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var value = db.TblProduct.Find(id);
            db.TblProduct.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = db.TblProduct.Find(id);

            List<SelectListItem> values = (from i in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryID.ToString()
                                           }).ToList();
            ViewBag.value = values;

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProduct(TblProduct tblProduct)
        {
            var value = db.TblProduct.Find(tblProduct.ProductID);
            value.ProductName = tblProduct.ProductName;
            
            //value.CategoryID = tblProduct.CategoryID;
            var category = db.TblCategory.Where(m => m.CategoryID == tblProduct.TblCategory.CategoryID).FirstOrDefault();
            value.CategoryID = category.CategoryID;

            value.ProductBrand = tblProduct.ProductBrand;
            value.ProductStock = tblProduct.ProductStock;
            value.ProductPrice = tblProduct.ProductPrice;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}