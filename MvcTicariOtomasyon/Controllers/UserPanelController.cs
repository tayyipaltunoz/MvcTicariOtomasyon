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
            var mail = (string) Session["Email"];
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
    }
}