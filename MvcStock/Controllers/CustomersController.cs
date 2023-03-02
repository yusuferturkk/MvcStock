using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class CustomersController : Controller
    {

        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult Index(string p)
        {
            var values = from v in db.TblCustomer select v;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(c => c.CustomerName.Contains(p));
            }
            return View(values.ToList());

            //var customers = db.TblCustomer.ToList();
            //return View(customers);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(TblCustomer p1)
        {
            db.TblCustomer.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var value = db.TblCustomer.Find(id);
            db.TblCustomer.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            var value = db.TblCustomer.Find(id);
            return View(value); 
        }

        [HttpPost]
        public ActionResult UpdateCustomer(TblCustomer tblCustomer)
        {
            var value = db.TblCustomer.Find(tblCustomer.CustomerID);
            value.CustomerName = tblCustomer.CustomerName;
            value.CustomerSurname = tblCustomer.CustomerSurname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}