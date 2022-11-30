using Luxor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Luxor.Controllers
{
    public class HomeController : BaseController
    {
       // [AllowAnonymous]
        public ActionResult Index()
        {
            var cities = new List<City>();
            cities.Add(new City() { Title = "Magdeburg", Descripion="Hier finden Sie unseres Zentrum", Lat = 52.122749178442675,Lng= 11.626994584514913 });
            cities.Add(new City() { Title = "Leipzig", Descripion = "Hier finden Sie unseres Zentrum", Lat = 51.38451540801481, Lng = 12.303772906292798 });
            cities.Add(new City() { Title = "Berlin", Descripion = "Hier finden Sie unseres Zentrum", Lat = 52.57294789999966, Lng = 13.404198421370529 });
            cities.Add(new City() { Title = "Hanover", Descripion = "Hier finden Sie unseres Zentrum", Lat = 52.37978405614866, Lng = 9.73229242650411 });

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}