//using SakaryaBufe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakaryaBufe.Controllers
{
    public class HomeController : Controller
    {
        SakaryaBufe.SakaryaBufeEntities1 db = new SakaryaBufeEntities1();
        public ActionResult Index()
        {
            
            return View();

        }
        public ActionResult Slider()
        {
            var sliders = db.Mansets.Where(x => x.id > 0);   // id si 0 dan buyuk degerleri getirmeye yarar (Bos deger dondurmesini engellemek için)
            return View(sliders);

        }
        public ActionResult UrunGetir()
        {
            var urunlerr = db.Urunlers.Where(X => X.id > 0);   // id si 0 dan buyuk degerleri getirmeye yarar (Bos deger dondurmesini engellemek için)
            return View(urunlerr);

        }
        public ActionResult Galeri()
        {
            var resimler = db.Resimlers.Where(x => x.id > 0);   // id si 0 dan buyuk degerleri getirmeye yarar (Bos deger dondurmesini engellemek için)
            return View(resimler);
        }
    }
}
