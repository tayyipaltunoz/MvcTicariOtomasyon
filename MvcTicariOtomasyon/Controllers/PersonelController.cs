using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        private Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> dgr1 = (from x in c.Departmen.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.DepartmanId.ToString()
                                         }).ToList();
            ViewBag.dgr1 = dgr1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Theme/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Theme/Image/" + dosyaadi + uzanti;
            }

            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGüncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Theme/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Theme/Image/" + dosyaadi + uzanti;
            }
            var prs = c.Personels.Find(p.PersonelId);
            prs.PersonelAd = p.PersonelAd;
            prs.PersonelSoyad = p.PersonelSoyad;
            prs.PersonelGorsel = p.PersonelGorsel;
            prs.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }

    }
}