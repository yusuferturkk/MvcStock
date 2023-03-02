using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class SalesController : Controller
    {
        
        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddSale()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSale(TblSale tblSale)
        {
            db.TblSale.Add(tblSale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}