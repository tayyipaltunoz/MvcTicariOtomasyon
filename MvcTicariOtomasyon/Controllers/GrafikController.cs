using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
using WebGrease.Css.Extensions;

namespace MvcTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        private Context _context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        //Controller Tarafında Grafik Oluşturma

        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori Ürün Stok Sayısı").AddLegend("Stok").AddSeries
            ("Değerler", xValue: new[] { "Bilgisayar", "Televizyon", "Küçük Ev Aletleri", "Beyaz Eşya" },
                yValues: new[] { 300, 250, 50, 100 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        //Grafiklere Veri Tabanından Veri Çekme

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = _context.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800).AddTitle("Stoklar")
                .AddSeries(chartType: "pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        //Google Charts Controller

        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        //  InMemory grafik
        public List<GoogleGrafik> UrunListesi()
        {
            List<GoogleGrafik> snf = new List<GoogleGrafik>();
            snf.Add(new GoogleGrafik()
            {
                urunAd = "Bilgisayar",
                stok = 120
            });
            snf.Add(new GoogleGrafik()
            {
                urunAd = "Beyaz Eşya",
                stok = 150,
            });
            snf.Add(new GoogleGrafik()
            {
                urunAd = "Televizyon",
                stok = 150,
            });
            snf.Add(new GoogleGrafik()
            {
                urunAd = "Küçük Ev Aletleri",
                stok = 50,
            });
            return snf;
        }

        // veritabından grafik verilerini çekme

        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<GoogleCart> UrunListesi2()
        {
            List<GoogleCart> snf = new List<GoogleCart>();
            using (var c = new Context())
            {
                snf = c.Uruns.Select(x => new GoogleCart
                {
                    urn = x.UrunAd,
                    stk = x.Stok,
                }).ToList();
                return snf;
            }
        }
    }
}