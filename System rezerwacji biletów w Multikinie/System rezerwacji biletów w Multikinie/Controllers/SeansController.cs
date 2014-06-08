using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System_rezerwacji_biletów_w_Multikinie.Models;

namespace System_rezerwacji_biletów_w_Multikinie.Controllers
{
    [Authorize(Roles = "Admin,Worker")]
    public class SeansController : Controller
    {
        private MultikinoDb db = new MultikinoDb();

        //
        // GET: /Seans/

        public ActionResult Index()
        {
            return View(db.Seanse.ToList());
        }

        //
        // GET: /Seans/Details/5

        public ActionResult Details(int id = 0)
        {
            Seans seans = db.Seanse.Find(id);
            if (seans == null)
            {
                return HttpNotFound();
            }
            return View(seans);
        }

        //
        // GET: /Seans/Create

        public ActionResult Create()
        {
            ViewBag.TytułFilmu = new SelectList(db.Filmy, "ID", "Tytul");
            ViewBag.IdSali = new SelectList(db.Sale, "ID", "ID");
            return View();
        }

        //
        // POST: /Seans/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seans seans)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(seans.TytułFilmu);
                seans.TytułFilmu = db.Filmy.Find(id).Tytul;
                db.Seanse.Add(seans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seans);
        }

        //
        // GET: /Seans/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Seans seans = db.Seanse.Find(id);
            if (seans == null)
            {
                return HttpNotFound();
            }
            return View(seans);
        }

        //
        // POST: /Seans/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Seans seans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seans);
        }

        //
        // GET: /Seans/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Seans seans = db.Seanse.Find(id);
            if (seans == null)
            {
                return HttpNotFound();
            }
            return View(seans);
        }

        //
        // POST: /Seans/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seans seans = db.Seanse.Find(id);
            db.Seanse.Remove(seans);
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