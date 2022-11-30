using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Luxor.Models;

namespace Luxor.Controllers
{
    public class EinschreibungsController : BaseController
    {
        private NilEntities db = new NilEntities();

        // GET: Einschreibungs
        public ActionResult Index()
        {
            var einschreibungs = db.Einschreibungs.Include(e => e.Kurs).Include(e => e.Student);
            return View(einschreibungs.ToList());
        }

        // GET: Einschreibungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Einschreibung einschreibung = db.Einschreibungs.Find(id);
            if (einschreibung == null)
            {
                return HttpNotFound();
            }
            return View(einschreibung);
        }

        // GET: Einschreibungs/Create
        public ActionResult Create()
        {
            ViewBag.KursID = new SelectList(db.Kurs1, "KursID", "Titel");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "NachName");
            return View();
        }

        // POST: Einschreibungs/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EinschreibungID,Noten,KursID,StudentID")] Einschreibung einschreibung)
        {
            if (ModelState.IsValid)
            {
                db.Einschreibungs.Add(einschreibung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KursID = new SelectList(db.Kurs1, "KursID", "Titel", einschreibung.KursID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "NachName", einschreibung.StudentID);
            return View(einschreibung);
        }

        // GET: Einschreibungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Einschreibung einschreibung = db.Einschreibungs.Find(id);
            if (einschreibung == null)
            {
                return HttpNotFound();
            }
            ViewBag.KursID = new SelectList(db.Kurs1, "KursID", "Titel", einschreibung.KursID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "NachName", einschreibung.StudentID);
            return View(einschreibung);
        }

        // POST: Einschreibungs/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EinschreibungID,Noten,KursID,StudentID")] Einschreibung einschreibung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(einschreibung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KursID = new SelectList(db.Kurs1, "KursID", "Titel", einschreibung.KursID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "NachName", einschreibung.StudentID);
            return View(einschreibung);
        }

        // GET: Einschreibungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Einschreibung einschreibung = db.Einschreibungs.Find(id);
            if (einschreibung == null)
            {
                return HttpNotFound();
            }
            return View(einschreibung);
        }

        // POST: Einschreibungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Einschreibung einschreibung = db.Einschreibungs.Find(id);
            db.Einschreibungs.Remove(einschreibung);
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
