using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context Context = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var degerler = Context.Uruns.ToList();

            cs.Deger1 = Context.Uruns.Where(x => x.UrunId == 5).ToList();
            cs.Deger2 = Context.Detaylar.Where(y => y.detayId == 1).ToList();
            return View(cs);
        }
    }
}