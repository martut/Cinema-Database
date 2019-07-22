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
    public class BiletsController : Controller
    {
        private KinoContext db = new KinoContext();

        // GET: Bilets
        public ActionResult Index()
        {
            var bilets = db.Bilets.Include(b => b.Miejsce).Include(b => b.Seans);
            return View(bilets.ToList());
        }

        // GET: Bilets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilets.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // GET: Bilets/Create
        public ActionResult Create()
        {
            ViewBag.MiejsceId = new SelectList(db.Miejsces, "MiejsceId", "MiejsceId");
            ViewBag.SeansId = new SelectList(db.Seanss, "SeansId", "SeansId");
            return View();
        }

        // POST: Bilets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BiletId,Price,MiejsceId,SeansId")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                db.Bilets.Add(bilet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MiejsceId = new SelectList(db.Miejsces, "MiejsceId", "MiejsceId", bilet.MiejsceId);
            ViewBag.SeansId = new SelectList(db.Seanss, "SeansId", "SeansId", bilet.SeansId);
            return View(bilet);
        }

        // GET: Bilets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilets.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MiejsceId = new SelectList(db.Miejsces, "MiejsceId", "MiejsceId", bilet.MiejsceId);
            ViewBag.SeansId = new SelectList(db.Seanss, "SeansId", "SeansId", bilet.SeansId);
            return View(bilet);
        }

        // POST: Bilets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BiletId,Price,MiejsceId,SeansId")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bilet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MiejsceId = new SelectList(db.Miejsces, "MiejsceId", "MiejsceId", bilet.MiejsceId);
            ViewBag.SeansId = new SelectList(db.Seanss, "SeansId", "SeansId", bilet.SeansId);
            return View(bilet);
        }

        // GET: Bilets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilets.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // POST: Bilets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bilet bilet = db.Bilets.Find(id);
            db.Bilets.Remove(bilet);
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
