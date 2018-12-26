using SakaryaBufe.Models;
using System.Linq;
using System.Web.Mvc;

namespace SakaryaBufe.Controllers
{
    public class HomeController : Controller
    {
        SakaryaEntities db = new SakaryaEntities();

        public ActionResult Index()
        {
            var kategories = db.Kategoris.ToList();
            return View(kategories);
        }

        public ActionResult Iletisim()
        {
            return View();
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult UrunGetir()
        {
            var urunlers = db.Urunlers.Where(X => X.id > 0);   // id si 0 dan buyuk degerleri getirmeye yarar (Bos deger dondurmesini engellemek için)
            return View(urunlers);
        }

        public ActionResult _Slider()
        {
            var urunlers = db.Urunlers.Where(X => X.id > 0).OrderByDescending(x=>x.id).Take(5);   // id si 0 dan buyuk degerleri getirmeye yarar (Bos deger dondurmesini engellemek için)
            return View(urunlers);
        }

        public ActionResult _nav()
        {
            var navs = db.Kategoris.ToList();
            if (navs == null)
                return View();
            return View(navs);
        }

        public ActionResult UrunlerListele(int id)
        {
            var model = db.Urunlers.Where(x => x.Kategori == id).ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult SatinAl(int id)
        {
            var model = db.Urunlers.Find(id);
            if(model!=null)
            {
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UrunDetay(int id)
        {
            var model = db.Urunlers.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
