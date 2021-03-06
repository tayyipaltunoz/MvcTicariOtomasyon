using MvcTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        private Context _context = new Context();

        public ActionResult Index(int sayfa = 1)
        {
            var degerler = _context.Kategoris.ToList().ToPagedList(sayfa, 10);
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

        public ActionResult Cascading()
        {
            KategoriUrunCascading cs = new KategoriUrunCascading();
            cs.Kategoriler = new SelectList(_context.Kategoris, "KategoriId", "KategoriAd");
            cs.Urunler = new SelectList(_context.Uruns, "UrunId", "UrunAd");
            return View(cs);
        }

        public ActionResult UrunGetir(int p)
        {
            var urunlistesi = (from x in _context.Uruns
                               join y in _context.Kategoris
                                   on x.Kategori.KategoriId equals y.KategoriId
                               where x.Kategori.KategoriId == p
                               select new
                               {
                                   Text = x.UrunAd,
                                   Value = x.UrunId.ToString()
                               }).ToList();
            return Json(urunlistesi, JsonRequestBehavior.AllowGet);
        }
    }
}