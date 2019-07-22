using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KinoOpolwood.DAL;
using KinoOpolwood.Models;

namespace KinoOpolwood.Controllers
{
    public class RezerwacjasController : Controller
    {
        private KinoContext db = new KinoContext();

        // GET: Rezerwacjas
        public ActionResult Index()
        {
            var rezerwacjas = db.Rezerwacjas.Include(r => r.Klient).Include(r => r.Miejsce).Include(r => r.Seans);
            return View(rezerwacjas.ToList());
        }

        // GET: Rezerwacjas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacja rezerwacja = db.Rezerwacjas.Find(id);
            if (rezerwacja == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacja);
        }

        // GET: Rezerwacjas/Create
        public ActionResult Create()
        {
            ViewBag.KlientId = new SelectList(db.Klients, "KlientId", "FirstName");
            ViewBag.MiejsceId = new SelectList(db.Miejsces, "MiejsceId", "MiejsceId");
            ViewBag.SeansId = new SelectList(db.Seanss, "SeansId", "SeansId");
            return View();
        }

        // POST: Rezerwacjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RezerwacjaId,MiejsceId,KlientId,SeansId")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                db.Rezerwacjas.Add(rezerwacja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlientId = new SelectList(db.Klients, "KlientId", "FirstName", rezerwacja.KlientId);
            ViewBag.MiejsceId = new SelectList(db.Miejsces, "MiejsceId", "MiejsceId", rezerwacja.MiejsceId);
            ViewBag.SeansId = new SelectList(db.Seanss, "SeansId", "SeansId", rezerwacja.SeansId);
            return View(rezerwacja);
        }

        // GET: Rezerwacjas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacja rezerwacja = db.Rezerwacjas.Find(id);
            if (rezerwacja == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlientId = new SelectList(db.Klients, "KlientId", "FirstName", rezerwacja.KlientId);
            ViewBag.MiejsceId = new SelectList(db.Miejsces, "MiejsceId", "MiejsceId", rezerwacja.MiejsceId);
            ViewBag.SeansId = new SelectList(db.Seanss, "SeansId", "SeansId", rezerwacja.SeansId);
            return View(rezerwacja);
        }

        // POST: Rezerwacjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RezerwacjaId,MiejsceId,KlientId,SeansId")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezerwacja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlientId = new SelectList(db.Klients, "KlientId", "FirstName", rezerwacja.KlientId);
            ViewBag.MiejsceId = new SelectList(db.Miejsces, "MiejsceId", "MiejsceId", rezerwacja.MiejsceId);
            ViewBag.SeansId = new SelectList(db.Seanss, "SeansId", "SeansId", rezerwacja.SeansId);
            return View(rezerwacja);
        }

        // GET: Rezerwacjas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezerwacja rezerwacja = db.Rezerwacjas.Find(id);
            if (rezerwacja == null)
            {
                return HttpNotFound();
            }
            return View(rezerwacja);
        }

        // POST: Rezerwacjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezerwacja rezerwacja = db.Rezerwacjas.Find(id);
            db.Rezerwacjas.Remove(rezerwacja);
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
