using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LogInController : Controller
    {
        // GET: LogIn
        private Context _context = new Context();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Register(Cariler c)
        {
            _context.Carilers.Add(c);
            _context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Cariler c)
        {
            var bilgiler = _context.Carilers.FirstOrDefault(x => x.CariMail == c.CariMail && x.CariSifre == c.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["Email"] = bilgiler.CariMail.ToString();
                return RedirectToAction("AnaSayfa", "Home");
            }
            else
            {
                return RedirectToAction("Index", "LogIn");
            }

        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = _context.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("AnaSayfa", "Home");
            }
            else
            {
                return RedirectToAction("Index", "LogIn");
                
            }
        }

        public ActionResult Demo()
        {
           
            return RedirectToAction("AnaSayfa", "Home");
        }
    }
}