using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SakaryaBufe.Models;


namespace SakaryaBufe.Controllers
{
    public class UyelikController : Controller
    {
        SakaryaEntities db = new SakaryaEntities();

        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Uyeler uye)
        {
            var kisi = db.Uyelers.FirstOrDefault(x => x.Eposta == uye.Eposta && x.Sifre == uye.Sifre);

            if(kisi != null)
            {
                FormsAuthentication.SetAuthCookie(kisi.Ad , false);
                return RedirectToAction("Index" , "Home");
            }
            else
            {
                ViewBag.Hata = "Kullanıcı Adı veya Şifre Hatası";
                return View();
            }
        }

        [Authorize]
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Uyelik");
           
        }

        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(Uyeler uye)
        {
            if (ModelState.IsValid)
            {
                var model = db.Uyelers.FirstOrDefault(x => x.Eposta == uye.Eposta);
                if(model != null)
                {
                    ViewBag.Hata = "Bu eposta daha önce kullanılmış lütfen başka eposta ile kayıt olmayı deneyiniz..";
                    return View();
                }
                else
                {
                    uye.Role = "U";
                    db.Uyelers.Add(uye);
                    db.SaveChanges();
                    
                    return RedirectToAction("GirisYap", "Uyelik" );
                }
            }
            else
            {
                return View();
            }
        }

















        
        
        //GET: Uyelik
        public ActionResult KullanıcıEkle()
        {
            return View();

        }
        [HttpPost]

 //    public ActionResult KullanıcıEkle(string Ad, string Sifre, string Eposta, string /Telefon,/ string Adres)   //Baslik string geldigi için string alınır
 //    {    
 //           Kullanici k = new Kullanici();
 //        k.Ad = Ad;
 //        k.Sifre = Sifre;
 //        k.Eposta = Eposta;
 //        k.Telefon = Telefon;
 //        k.Adres = Adres;
 //        db.Kullanicis.Add(k);
 //        db.SaveChanges();
 //
 //        return Redirect( "KullanıcıGirisYap");    // Siparis gönderildikten sonra index //sayfasına dönmek için
 //    }
 //
        public ActionResult KullanıcıGirisYap()
        {
            return View();

        }
        [HttpPost]
        public ActionResult KullanıcıGirisYap(string Sifre, string Eposta)
        {
            // KullaniciGiri kg = new KullaniciGiri();
            // kg.Eposta = Eposta;
            // kg.Sifre = Sifre;
            // return Redirect("/");
            return View();
        }

    }

}