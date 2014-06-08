using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System_rezerwacji_biletów_w_Multikinie.Models;
using Newtonsoft.Json;
using WebMatrix.WebData;

namespace Filmowo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<UserProfile> user;
            using (var db = new MultikinoDb())
            {
                user = new List<UserProfile>();
                user = db.UserProfiles.ToList();
            }
            user = user.Where(u => u.UserName != User.Identity.Name).ToList();
            user = user.Where(u => u.UserName != "Admin").ToList();            
            return View(user);
        }

        //detale kuriera tam bedzie yswietlanie jsona :)
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem {Text = "Admin", Value = "1"});

            items.Add(new SelectListItem {Text = "Worker", Value = "2"});

            ViewBag.Role = new SelectList(items, "Text", "Text",items[1]);
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(RegisterModel user)
        {
            if (ModelState.IsValid)
            {

                try
                {
                  
                    WebSecurity.CreateUserAndAccount(user.UserName, user.Password);
                    Roles.AddUserToRole(user.UserName, user.Role);
                    UserProfile userProfile;
                    using (var db =new  MultikinoDb())
                    {
                        var lista = db.UserProfiles.Where(n => n.UserName == user.UserName).ToList();
                        int id  = lista[0].UserId;
                        userProfile = db.UserProfiles.Find(id);
                        userProfile.Role = user.Role;
                        db.Entry(userProfile).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch (MembershipCreateUserException e)
                {
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            using (var db = new MultikinoDb())
            {
                UserProfile user = db.UserProfiles.Find(id);
                try
                {
                    Roles.RemoveUserFromRole(user.UserName, user.Role);
                    ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(user.UserName);
                    db.UserProfiles.Remove(user);
                    db.SaveChanges();
                }
                catch 
                {
                    //bład nie da sue usunać
                }
                return RedirectToAction("Index");
            }
        }
    }
}

