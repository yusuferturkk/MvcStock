using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class CategoriesController : Controller
    {

        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult Index(int sayfa = 1)
        {
            var categories = db.TblCategory.ToList().ToPagedList(sayfa, 4);
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategory p1)
        {
            db.TblCategory.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            db.TblCategory.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategory tblCategory)
        {
            var value = db.TblCategory.Find(tblCategory.CategoryID);
            value.CategoryName = tblCategory.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}