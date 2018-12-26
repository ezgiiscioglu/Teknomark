using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SakaryaBufe.Models;

namespace SakaryaBufe.Controllers
{
    [Authorize(Roles ="A")]
    public class UrunlerController : Controller
    {
        private SakaryaEntities db = new SakaryaEntities();

        public ActionResult SatinAl()
        {
            return View();
        }


        // GET: Urunler
        public ActionResult Index()
        {
            var urunlers = db.Urunlers.Include(u => u.Resimler).Include(u => u.Kategori1);
            return View(urunlers.ToList());
        }

        // GET: Urunler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // GET: Urunler/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Resimlers, "id", "ResimYolu");
            ViewBag.Kategori = new SelectList(db.Kategoris, "id", "kategoriAd");
            return View();
        }

        // POST: Urunler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Baslik,Aciklama,ResimYol,Fiyat,Kategori")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase httpPostedFileBase = Request.Files[0];
                if (httpPostedFileBase != null)
                {
                    string fileNameNew = Guid.NewGuid().ToString() + "_" + httpPostedFileBase.FileName;

                    string filePath = Path.Combine(Server.MapPath("~/Content/images"), fileNameNew);

                    httpPostedFileBase.SaveAs(filePath);

                    urunler.ResimYol = fileNameNew;

                }
                db.Urunlers.Add(urunler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Resimlers, "id", "ResimYolu", urunler.id);
            ViewBag.Kategori = new SelectList(db.Kategoris, "id", "kategoriAd", urunler.Kategori);
            return View(urunler);
        }

        // GET: Urunler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Resimlers, "id", "ResimYolu", urunler.id);
            ViewBag.Kategori = new SelectList(db.Kategoris, "id", "kategoriAd", urunler.Kategori);
            return View(urunler);
        }

        // POST: Urunler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Baslik,Aciklama,ResimYol,Fiyat,Kategori")] Urunler urunler)
        {

            if (ModelState.IsValid)
            {
                if(urunler.ResimYol != null)
                {
                    string filePathOld = Path.Combine(Server.MapPath("~/Content/images"), urunler.ResimYol);

                    if (System.IO.File.Exists(filePathOld))
                    {
                        System.IO.File.Delete(filePathOld);
                    }

                }

                HttpPostedFileBase httpPostedFileBase = Request.Files[0];
                if (httpPostedFileBase != null)
                {
                    string fileNameNew = Guid.NewGuid().ToString() + "_" + httpPostedFileBase.FileName;

                    string filePath = Path.Combine(Server.MapPath("~/Content/images"), fileNameNew);

                    httpPostedFileBase.SaveAs(filePath);

                    urunler.ResimYol = fileNameNew;

                }

                db.Entry(urunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Resimlers, "id", "ResimYolu", urunler.id);
            ViewBag.Kategori = new SelectList(db.Kategoris, "id", "kategoriAd", urunler.Kategori);
            return View(urunler);
        }

        // GET: Urunler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: Urunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urunler urunler = db.Urunlers.Find(id);
            db.Urunlers.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
