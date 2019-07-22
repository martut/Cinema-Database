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
    public class MiejscesController : Controller
    {
        private KinoContext db = new KinoContext();

        // GET: Miejsces
        public ActionResult Index()
        {
            var miejsces = db.Miejsces.Include(m => m.Sala);
            return View(miejsces.ToList());
        }

        // GET: Miejsces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miejsce miejsce = db.Miejsces.Find(id);
            if (miejsce == null)
            {
                return HttpNotFound();
            }
            return View(miejsce);
        }

        // GET: Miejsces/Create
        public ActionResult Create()
        {
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "SalaId");
            return View();
        }

        // POST: Miejsces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MiejsceId,SalaId,SeatNumber,RowNumber")] Miejsce miejsce)
        {
            if (ModelState.IsValid)
            {
                db.Miejsces.Add(miejsce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "SalaId", miejsce.SalaId);
            return View(miejsce);
        }

        // GET: Miejsces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miejsce miejsce = db.Miejsces.Find(id);
            if (miejsce == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "SalaId", miejsce.SalaId);
            return View(miejsce);
        }

        // POST: Miejsces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MiejsceId,SalaId,SeatNumber,RowNumber")] Miejsce miejsce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miejsce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "SalaId", miejsce.SalaId);
            return View(miejsce);
        }

        // GET: Miejsces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miejsce miejsce = db.Miejsces.Find(id);
            if (miejsce == null)
            {
                return HttpNotFound();
            }
            return View(miejsce);
        }

        // POST: Miejsces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miejsce miejsce = db.Miejsces.Find(id);
            db.Miejsces.Remove(miejsce);
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
