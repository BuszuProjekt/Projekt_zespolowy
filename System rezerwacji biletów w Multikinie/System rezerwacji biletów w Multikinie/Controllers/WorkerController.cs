using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System_rezerwacji_biletów_w_Multikinie.Models;

namespace System_rezerwacji_biletów_w_Multikinie.Controllers
{
    public class WorkerController : Controller
    {
        //
        // GET: /Worker/
        [Authorize(Roles = "Admin,Worker")]
        public ActionResult Index()
        {
            List<Bilet> bilety;
            using (var db = new MultikinoDb())
            {
                bilety = db.Bilety.ToList();

            }
            return View(bilety);
        }

        public ActionResult Usun(int id = 0)
        {
            Bilet bilet;
            using (var db = new MultikinoDb())
            {
                bilet = db.Bilety.Find(id);
                db.Bilety.Remove(bilet);
                //usunieto bilet
            }
           return RedirectToAction("Index");
        }

    }
}
