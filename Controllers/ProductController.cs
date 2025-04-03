using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_50Ders.Models.Entity;

namespace MVC_50Ders.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.tblUrunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values = (from x in db.tblKategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAd,
                                               Value = x.kategoriID.ToString()
                                           }).ToList();
            ViewBag.Kategoriler = values;
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(tblUrunler p)
        {
            var ctg=db.tblKategoriler.Where(m => m.kategoriID == p.tblKategoriler.kategoriID).FirstOrDefault();
            p.tblKategoriler = ctg;
            db.tblUrunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var urun = db.tblUrunler.Find(id);
            db.tblUrunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}