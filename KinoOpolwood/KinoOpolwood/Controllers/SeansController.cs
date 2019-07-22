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
    public class SeansController : Controller
    {
        private KinoContext db = new KinoContext();

        // GET: Seans
        public ActionResult Index()
        {
            var seanss = db.Seanss.Include(s => s.Film).Include(s => s.Sala);
            return View(seanss.ToList());
        }

        // GET: Seans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seans seans = db.Seanss.Find(id);
            if (seans == null)
            {
                return HttpNotFound();
            }
            return View(seans);
        }

        // GET: Seans/Create
        public ActionResult Create()
        {
            ViewBag.FilmId = new SelectList(db.Films, "FilmId", "Title");
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "SalaId");
            return View();
        }

        // POST: Seans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeansId,FilmId,SalaId,StartDate")] Seans seans)
        {
            if (ModelState.IsValid)
            {
                db.Seanss.Add(seans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmId = new SelectList(db.Films, "FilmId", "Title", seans.FilmId);
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "SalaId", seans.SalaId);
            return View(seans);
        }

        // GET: Seans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seans seans = db.Seanss.Find(id);
            if (seans == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmId = new SelectList(db.Films, "FilmId", "Title", seans.FilmId);
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "SalaId", seans.SalaId);
            return View(seans);
        }

        // POST: Seans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeansId,FilmId,SalaId,StartDate")] Seans seans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmId = new SelectList(db.Films, "FilmId", "Title", seans.FilmId);
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "SalaId", seans.SalaId);
            return View(seans);
        }

        // GET: Seans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seans seans = db.Seanss.Find(id);
            if (seans == null)
            {
                return HttpNotFound();
            }
            return View(seans);
        }

        // POST: Seans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seans seans = db.Seanss.Find(id);
            db.Seanss.Remove(seans);
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
