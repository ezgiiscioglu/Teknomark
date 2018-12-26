

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakaryaBufe.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        SakaryaBufe.SakaryaBufeEntities1 db = new SakaryaBufeEntities1();
       

        public ActionResult Index()
        {
            return View();
        }
      
        
        public ActionResult SatinAl(int id)  
        {
            return View(db.Urunlers.FirstOrDefault(x => x.id == id));  // Gönderilen id degerinde herhangi bir ürün varsa bunu geri gönderir.
        }
        [HttpPost]

        public ActionResult SatinAl(string Urun, string Mail, string İsim, string Telefon, string Mesaj)   //Baslik string geldigi için string alınır
        {
            if(Urun==null)
            { 
            MesajBox ms = new MesajBox();
            ms.AdSoyad = İsim;
            ms.Mail = Mail;
            ms.Telefon = Telefon;
            ms.Urun = "Mesaj !";
            ms.Mesaj = Mesaj;
            db.MesajBoxes.Add(ms);
            db.SaveChanges();

            return Redirect("/");    // Siparis gönderildikten sonra index sayfasına dönmek için
}
            else
            {
                MesajBox ms = new MesajBox();
                ms.AdSoyad = İsim;
                ms.Mail = Mail;
                ms.Telefon = Telefon;
                ms.Urun = "Sipariş !";
                ms.Mesaj = Mesaj;
                db.MesajBoxes.Add(ms);
                db.SaveChanges();

                return Redirect("/");
            }
        }
    }
}
