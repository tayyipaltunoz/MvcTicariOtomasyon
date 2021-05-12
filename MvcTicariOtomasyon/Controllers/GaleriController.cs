using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context Context = new Context();
        public ActionResult Index()
        {
            var degerler = Context.Uruns.ToList();
            return View(degerler);
        }
    }
}