using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System_rezerwacji_biletów_w_Multikinie.Models;

namespace System_rezerwacji_biletów_w_Multikinie.Controllers
{
    [Authorize(Roles = "Admin,Worker")]
    public class SalaController : Controller
    {
        private MultikinoDb db = new MultikinoDb();

        //
        // GET: /Sala/

        public ActionResult Index()
        {
            return View(db.Sale.ToList());
        }

        //
        // GET: /Sala/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sala/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Sale.Add(sala);
                db.SaveChanges();
                var sale = db.Sale.ToList();
                int id = 0;
                foreach (var item in sale)
                {
                    id = item.ID;
                }
                sala = db.Sale.Find(id);
                for (int i = 1; i <= sala.IlośćMiejsc; i++)
                {
                    Miejsce miejsce = new Miejsce();
                    miejsce.IdSali = sala.ID;
                    miejsce.Identyfikator = Convert.ToString(i);
                    db.Miejsca.Add(miejsce); 
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(sala);
        }

        //
        // GET: /Sala/Delete/5

        public ActionResult Delete(int id)
        {
            Sala sala = db.Sale.Find(id);
            db.Sale.Remove(sala);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}