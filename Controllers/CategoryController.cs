using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_50Ders.Models.Entity;

namespace MVC_50Ders.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DbMvcStokEntities1 db = new DbMvcStokEntities1();

        public ActionResult Index()
        {
            var values = db.tblKategoriler.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(tblKategoriler p)
        {
            db.tblKategoriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var category = db.tblKategoriler.Find(id);
            db.tblKategoriler.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {
            var category = db.tblKategoriler.Find(id);
            return View("GetCategory", category);
        }

        [HttpPost]
        public ActionResult Update(tblKategoriler id)
        {
            var category = db.tblKategoriler.Find(id.kategoriID);
            category.kategoriAd = id.kategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}