using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_50Ders.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bu mesaj Senin hakkında sayfan controllerdan about action geldi.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Bu mesaj Senin hakkında sayfan controllerdan contact action geldi.";

            return View();
        }
        public ActionResult Bilgi()
        {
            ViewBag.Message = "Bu mesaj Senin bilgi sayfan controllerdan bilgi action geldi.";
            return View();
        }

        public ActionResult Profil()
        {
            ViewBag.AdSoyad = "Nesrin Düzgün";
            ViewBag.Yas = 23;
            ViewBag.Meslek = "Yazılım Mühendisi";
            ViewBag.Sehir = "İstanbul";
            return View();
        }
    }
}