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

           
            var deger1 = _context.SatisHarekets.Count().ToString();
            ViewBag.d1 = deger1;

            return View(urunler);
        }

    }
}