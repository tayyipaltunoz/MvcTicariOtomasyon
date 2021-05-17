using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        private Context _context = new Context();
        public ActionResult Index(string p)
        {
            var kargo = from x in _context.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargo = kargo.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargo.ToList());
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            _context.KargoDetays.Add(d);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karekterler = { "A", "B", "C", "D", "E", "F", "G" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karekterler.Length);
            k2 = rnd.Next(0, karekterler.Length);
            k3 = rnd.Next(0, karekterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karekterler[k1] + s2 + karekterler[k2] + s3 + karekterler[k3];
            ViewBag.takipkod = kod;

            return View();
        }

        public ActionResult KargoTakip(string id)
        {
         
            var degerler = _context.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
    }
}