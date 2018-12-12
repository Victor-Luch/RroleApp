using RroleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RroleApp.Areas.GuideArea.Models;
using System.Net;

namespace RroleApp.Areas.GuideArea.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var guiD = db.Guides.Include(p => p.HeroGuid).Include(x=>x.ItemG);
            return View(guiD.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guide guide = db.Guides.Include(y => y.HeroGuid).Include(p => p.ItemG).FirstOrDefault(x => x.GuideId == id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }
      

        public ActionResult Create()
        {
            ViewBag.HeroOptId = new SelectList(db.HeroOpts, "HeroOptId", "Name");
            var _item = db.Items.Select(c => new { ItemID = c.ItemId, ItemNamE = c.ItemName }).ToList();
            ViewBag.Items = new MultiSelectList(_item, "ItemID", "ItemNamE");
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuideViewModel guideView)
        {
            if (ModelState.IsValid)
            {
                var guide = new Guide
                {
                    GuideId = guideView.GuideId,
                    GuideName = guideView.GuideName,
                    HeroOptId = guideView.HeroOptId,


                };
                foreach(var item in guideView.ItemId)
                {
                    guide.ItemG.Add(db.Items.FirstOrDefault(x => x.ItemId == item));
                }
                db.Guides.Add(guide);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.HeroOptId = new SelectList(db.HeroOpts, "HeroOptId", "Name", guideView.HeroOptId);
            return View(guideView);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {

            Guide guide = db.Guides.Include(y => y.HeroGuid).Include(p => p.ItemG).FirstOrDefault(x => x.GuideId == id);
            if (guide != null)
            {
                db.Guides.Remove(guide);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}