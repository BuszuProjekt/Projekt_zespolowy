using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System_rezerwacji_biletów_w_Multikinie.Models;

namespace System_rezerwacji_biletów_w_Multikinie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Seans> seanses;
            using (var db = new MultikinoDb())
            {
                seanses = db.Seanse.ToList();
            }
            return View(seanses);
        }

        public ActionResult Details(int id = 0)
        {
            Film film;
            using (var db = new MultikinoDb())
            {
                film = db.Filmy.Find(id);
            }

            return View(film);
        }

        //public ActionResult Miejsce(int id = 0)
        //{



        //}
    }
}
