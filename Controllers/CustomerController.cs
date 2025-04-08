using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_50Ders.Models.Entity;

namespace MVC_50Ders.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        public ActionResult Index(string p)
        {
            var values = from d in db.tblMusteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(m => m.musteriAd.Contains(p));
            }
            return View(values.ToList());

            //var degerler = db.tblMusteriler.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(tblMusteriler p)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            db.tblMusteriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)   
        {
            var musteri = db.tblMusteriler.Find(id);
            db.tblMusteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int id)
        {
            var musteri=db.tblMusteriler.Find(id);
            return View("GetCustomer", musteri);
        }

        [HttpPost]
        public ActionResult Update(tblMusteriler id)
        {
            var musteri = db.tblMusteriler.Find(id.musteriID);
            musteri.musteriAd = id.musteriAd;
            musteri.musteriSoyad = id.musteriSoyad;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}