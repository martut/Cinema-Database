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
    public class KlientsController : Controller
    {
        private KinoContext db = new KinoContext();

        // GET: Klients
        public ActionResult Index()
        {
            return View(db.Klients.ToList());
        }

        // GET: Klients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klients.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // GET: Klients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KlientId,FirstName,LastName,Adress")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                db.Klients.Add(klient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klient);
        }

        // GET: Klients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klients.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // POST: Klients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KlientId,FirstName,LastName,Adress")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klient);
        }

        // GET: Klients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klients.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // POST: Klients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klient klient = db.Klients.Find(id);
            db.Klients.Remove(klient);
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
