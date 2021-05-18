using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: UserPanel
        private Context _context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["Email"];
            var degerler = _context.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["Email"];
            var id = _context.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var degerler = _context.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }

        //***MESAJLAR***


        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["Email"];
            var mesajlar = _context.Mesajs.Where(x => x.Alici == mail).OrderByDescending(x=>x.MesajId).ToList();

            mesajsayi();
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["Email"];
            var mesajlar = _context.Mesajs.Where(x => x.Gonderici == mail).OrderByDescending(x => x.MesajId).ToList();

            mesajsayi();
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = _context.Mesajs.Where(x => x.MesajId == id).ToList();

            mesajsayi();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            mesajsayi();
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesaj mesaj)
        {
            var mail = (string)Session["Email"];
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesaj.Gonderici = mail;
            _context.Mesajs.Add(mesaj);
            _context.SaveChanges();
            return View();
        }

        public void mesajsayi()
        {
            var mail = (string)Session["Email"];
            var gidenSayisi = _context.Mesajs.Count(x => x.Gonderici == mail.ToString());
            ViewBag.gidenMesaj = gidenSayisi;
            var gelenSayisi = _context.Mesajs.Count(x => x.Alici == mail.ToString());
            ViewBag.gelenMesaj = gelenSayisi;

        }
    }
}