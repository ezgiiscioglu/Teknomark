using SakaryaBufe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SakaryaBufe.Areas.Yonetim.Controllers
{
    public class PanelController : Controller
    {
        SakaryaEntities db = new SakaryaEntities();

        [HttpGet]
        public ActionResult YonetimGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YonetimGiris(string mail, string pass)
        {
            var deger = db.Uyelers.FirstOrDefault(x => x.Eposta == mail && x.Sifre == pass);

            //Kullanıcı adı ve sifresi dogru girildiğinde yonetim //sayfasına yonlendırmeyı saglar

            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.Ad, false);
                //    Response.Redirect("Yonetim");
                return RedirectToAction("Index", "Urunler");
            }
            else
            {
                ViewBag.Hata = "Yönetici Giriş Bilgileri Hatalı";
                return View();
            }
        }

        public ActionResult YonetimCikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("YonetimGiris", new { lang = "tr" });
        }
          
    }
}