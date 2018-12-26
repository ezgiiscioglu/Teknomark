using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakaryaBufe.Controllers
{
    public class YonetimController : Controller
    {
        SakaryaBufe.SakaryaBufeEntities1 db = new SakaryaBufeEntities1();
        public ActionResult Slider()
        {
            return View(db.Mansets.ToList());
        }

        public ActionResult Mesaj()
        {
            return View(db.MesajBoxes.ToList());
        }
        // GET: Yonetim
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string id, string pass)
        {
            var deger = db.Logins.Where(x => x.Kullanici == id && x.Sifre == pass).FirstOrDefault();    //Kullanıcı adı ve sifresi dogru girildiğinde yonetim sayfasına yonlendırmeyı saglar
            if (deger != null)
            {
                Response.Redirect("Yonetim");
            }
            else
            {
                Response.Redirect("/");   //Kullanıcı adı ve sifresi yanlıs gırıldıgınde anasayfaya yonlendırme yapar
            }
            return View();
        }

        public ActionResult Yonetim()
        {
            return View(db.Urunlers.ToList());
        }
        public ActionResult Create(Urunler urun)    //Urunler sınıfından urun getirmek için
        {
            db.Urunlers.Add(urun);  // urun olusturma
            db.SaveChanges();
            return View();
        }
        public ActionResult Edit(int id)   
        {
            var gelen = db.Urunlers.Where(x => x.id == id).FirstOrDefault();

            return View(gelen);
        }
        [HttpPost]
        public ActionResult Edit(Urunler urun)    //Urunler sınıfından urun getirmek için
        {
            db.Entry(urun).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

    }
}

