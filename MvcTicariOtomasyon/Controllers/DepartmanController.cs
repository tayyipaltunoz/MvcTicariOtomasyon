using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        private Context c = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var degerler = c.Departmen.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmen.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmen.Find(id);
            return View("DepartmanGetir", dpt);
        }

        public ActionResult DeparmanGuncelle(Departman d)
        {
            var dpt = c.Departmen.Find(d.DepartmanId);
            dpt.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmen.Where(x => x.DepartmanId == id).Select(y =>
                y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);

        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var per = c.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}