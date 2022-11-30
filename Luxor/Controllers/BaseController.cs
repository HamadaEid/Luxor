using Luxor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luxor.Controllers
{
    public class BaseController : Controller

    {
        private NilEntities db = new NilEntities();
        static List<CourseStats> Stats = null;

        public BaseController()
        {
            Stats = new List<CourseStats>();

            var kursgruppe = db.Einschreibungs.GroupBy(g => g.Kurs.Titel);
            foreach(var group in kursgruppe)
            {
                Stats.Add(new CourseStats { KursTitel = group.Key, KursEinschreibung = group.Count() });

                    
            }
            ViewBag.CourseStats = Stats;
        }

        // GET: Base
    
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}