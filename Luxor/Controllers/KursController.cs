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
    public class KursController : BaseController
    {
        private NilEntities db = new NilEntities();

        // GET: Kurs
        //public ActionResult Index()
        //{
        //    return View(db.Kurs1.ToList());
        //}
        public ActionResult Index(string SearchString)
        {
            var kurse = from c in db.Kurs1 select c;

            if (!String.IsNullOrEmpty(SearchString))
            {
                kurse = kurse.Where(s => s.Titel.Contains(SearchString));
            }
            return View(kurse.ToList());
        }


        public ActionResult GetSearchValue(string search)
        {
            var selectedCourses = db.Kurs1
                .Where(c => c.Titel.Contains(search))
                .Select(x => new
            {
                Titel = x.Titel
            }).ToList();
            return new JsonResult { Data = selectedCourses, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
        public ActionResult StudentInKurs(string KursTitel)
        {
            var stds = db.Einschreibungs.Where(c => c.Kurs.Titel == KursTitel);
            return View(stds);
        }

        [HttpGet]
        public ActionResult IndexIndexMultipleDelete()
        {
            
            return View(db.Kurs1.ToList());
        }
        [HttpPost]
        public ActionResult IndexIndexMultipleDelete(FormCollection formCollection )
        {
            string[] ids = formCollection["ID"].Split(new char[] { ',' });

            foreach (var id in ids)
            {
                var kurs = db.Kurs1.Find(int.Parse(id));
                db.Kurs1.Remove(kurs);
                db.SaveChanges();
            }
        
            return View(db.Kurs1.ToList());
        }
        public ActionResult Test()
        {
            var kurs = new Kurs();
            kurs.Ebene = KursEbene.Mittlere;

            var kurse = db.GetKurs().ToList();
            return View(kurse);
        }
        // GET: Kurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurs kurs = db.Kurs1.Find(id);
            if (kurs == null)
            {
                return HttpNotFound();
            }
            return View(kurs);
        }

        // GET: Kurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kurs/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KursID,Titel,Kredite,KursBeschreibung,Ebene,IstKursAktiv")] Kurs kurs)
        {
            if (ModelState.IsValid)
            {
                db.Kurs1.Add(kurs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kurs);
        }

        // GET: Kurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurs kurs = db.Kurs1.Find(id);
            if (kurs == null)
            {
                return HttpNotFound();
            }
            return View(kurs);
        }

        // POST: Kurs/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KursID,Titel,Kredite")] Kurs kurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kurs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kurs);
        }

        // GET: Kurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurs kurs = db.Kurs1.Find(id);
            if (kurs == null)
            {
                return HttpNotFound();
            }
            return View(kurs);
        }

        // POST: Kurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kurs kurs = db.Kurs1.Find(id);
            db.Kurs1.Remove(kurs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteConfirmedJson(int id)
        {
            Kurs mitbewohner = db.Kurs1.Find(id);
            db.Kurs1.Remove(mitbewohner);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
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
