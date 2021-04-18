using MvcTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        private Context _context = new Context();

        public ActionResult Index()
        {
            var degerler = _context.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            _context.Kategoris.Add(k);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = _context.Kategoris.Find(id);
            _context.Kategoris.Remove(ktg);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = _context.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
           
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktg = _context.Kategoris.Find(k.KategoriId);
            ktg.KategoriAd = k.KategoriAd;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}