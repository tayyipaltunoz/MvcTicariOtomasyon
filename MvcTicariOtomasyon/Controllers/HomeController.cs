using MvcTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    
    public class HomeController : Controller
    {
        private Context _context = new Context();

        public ActionResult AnaSayfa()
        {
            var urunler = _context.Uruns.ToList();


            DateTime bugun = DateTime.Today;
            var deger1 = _context.SatisHarekets.Count(x =>  x.Tarih < bugun).ToString();
            ViewBag.satis = deger1;
            //toplam satış
            var topsat = _context.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.topsat = topsat;

            var topstok = _context.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.topstok = topstok;

            var topurun = _context.Uruns.Count().ToString();
            ViewBag.topurun = topurun;

            return View(urunler);
        }

    }
}