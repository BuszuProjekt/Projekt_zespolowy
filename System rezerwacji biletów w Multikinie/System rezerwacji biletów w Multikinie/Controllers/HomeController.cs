using System;
using System.Collections.Generic;
using System.Data;
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
        [Authorize]
        public ActionResult Miejsce(int id = 0)
        {

            using (var db = new MultikinoDb())
            {
                Seans seans = db.Seanse.Find(id);
                var id_sali = seans.IdSali;
                ViewBag.IdSeansu = id; //id seansu
                var lista = db.Miejsca.Where(i => i.IdSali == id_sali).ToList(); //lista miejsc
                return View(lista);
            }
        }
        [HttpPost]
        public ActionResult Miejsce(int id = 0,int id2=0)//id - id miejsca . id2 - id seansu
        {
            using (var db = new MultikinoDb())
            {
                Bilet bilet = new Bilet();
                bilet.IdMiejsca = id;
                bilet.IdSeansu = id2;
                string UserName = User.Identity.Name;
                var lista = db.UserProfiles.Where(u => u.UserName == UserName).ToList();
                bilet.IdUsera = lista.Last().UserId;
                db.Bilety.Add(bilet);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
