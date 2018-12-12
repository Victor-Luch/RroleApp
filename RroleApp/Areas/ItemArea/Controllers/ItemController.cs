using RroleApp.Areas.ItemArea.Models;
using RroleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RroleApp.Areas.ItemArea.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);

        }
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.FirstOrDefault(x => x.ItemId == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {

            Item item = db.Items.FirstOrDefault(x => x.ItemId == id);
            if (item != null)
            {
                db.Items.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}