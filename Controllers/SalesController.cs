using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_50Ders.Models.Entity;

namespace MVC_50Ders.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSales(tblSatislar p)
        {
            db.tblSatislar.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}