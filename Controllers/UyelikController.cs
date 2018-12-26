//using SakaryaBufe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakaryaBufe.Controllers
{
    public class UyelikController : Controller
    {
        SakaryaBufe.SakaryaBufeEntities1 db = new SakaryaBufeEntities1();


        //GET: Uyelik
        public ActionResult KullanıcıEkle()
        {
            return View();

        }
        [HttpPost]

        public ActionResult KullanıcıEkle(string Ad, string Sifre, string Eposta, string Telefon, string Adres)   //Baslik string geldigi için string alınır
        {    
               Kullanici k = new Kullanici();
            k.Ad = Ad;
            k.Sifre = Sifre;
            k.Eposta = Eposta;
            k.Telefon = Telefon;
            k.Adres = Adres;
            db.Kullanicis.Add(k);
            db.SaveChanges();

            return Redirect( "KullanıcıGirisYap");    // Kullanıcı eklendikten sonra giris yap sayfasına dönmek için
        }

        public ActionResult KullanıcıGirisYap()
        {
            return View();

        }
        [HttpPost]
        public ActionResult KullanıcıGirisYap(string Sifre, string Eposta)
        {
            KullaniciGiri kg = new KullaniciGiri();
            kg.Eposta = Eposta;
            kg.Sifre = Sifre;
            return Redirect("/");  // Kullanıcı giris yaptıktan sonra index sayfasına dönmek için
        }

    }

}