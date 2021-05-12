using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik  ** linq ile
        Context context = new Context();
        public ActionResult Index()
        {
            try
            {
                //toplam cari
                var deger1 = context.Carilers.Count().ToString();
                ViewBag.d1 = deger1;
                //Urun sayısı
                var deger2 = context.Uruns.Count().ToString();
                ViewBag.d2 = deger2;
                //personel sayisi
                var deger3 = context.Personels.Count().ToString();
                ViewBag.d3 = deger3;
                //kategori sayisi
                var deger4 = context.Kategoris.Count().ToString();
                ViewBag.d4 = deger4;
                //toplam stok 
                var deger5 = context.Uruns.Sum(x => x.Stok).ToString();
                ViewBag.d5 = deger5;
                //marka sayısı
                var deger6 = (from x in context.Uruns select x.Marka).Distinct().Count().ToString();
                ViewBag.d6 = deger6;
                //kritik seviye
                var deger7 = context.Uruns.Count(x => x.Stok <= 20).ToString();
                ViewBag.d7 = deger7;
                //max fiyatlı urun
                var deger8 = (from x in context.Uruns orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault();
                ViewBag.d8 = deger8;
                //minimum fiyatlı urun
                var deger9 = (from x in context.Uruns orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault();
                ViewBag.d9 = deger9;
                //marka haylou sayısı
                var deger10 = context.Uruns.Count(x => x.Marka == "Haylou").ToString();
                ViewBag.d10 = deger10;
                //marka acer sayısı
                var deger11 = context.Uruns.Count(x => x.Marka == "acer").ToString();
                ViewBag.d11 = deger11;
                //max marka
                var deger12 = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
                ViewBag.d12 = deger12;
                //en çok satan urun
                var deger13 =context.Uruns.Where(u => u.UrunId == (context.SatisHarekets.GroupBy(x => x.UrunID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
                ViewBag.d13 = deger13;
                //toplam tutar(kasadaki tutar)
                var deger14 = context.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
                ViewBag.d14 = deger14;
                //bugünki satis
                DateTime bugun = DateTime.Today;
                var deger15 = context.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
                ViewBag.d15 = deger15;
                //bugünki kasa
                var deger16 = context.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
                ViewBag.d16 = deger16;
               
            }
            catch (Exception)
            {
                
            }
           return View();
        }
    }
}