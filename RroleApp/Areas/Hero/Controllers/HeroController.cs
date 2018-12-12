using RroleApp.Areas.Hero.Models;
using RroleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RroleApp.Areas.Hero.Controllers
{
    public class HeroController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            return View(db.HeroOpts.ToList());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(HeroOpt heroOpt)
        {
            if (ModelState.IsValid)
            {
                db.HeroOpts.Add(heroOpt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heroOpt);

        }
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeroOpt heroOpt = db.HeroOpts.FirstOrDefault(x => x.HeroOptId == id);
            if (heroOpt == null)
            {
                return HttpNotFound();
            }
            return View(heroOpt);
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeroOpt heroOpt = db.HeroOpts.FirstOrDefault(x => x.HeroOptId == id);
            if (heroOpt == null)
            {
                return HttpNotFound();
            }
            return View(heroOpt);
        }
        
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(HeroOpt heroOpt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heroOpt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heroOpt);

        }

        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int id)
        {

            HeroOpt heroOpt = db.HeroOpts.FirstOrDefault(x => x.HeroOptId == id);
            if (heroOpt != null)
            {
                db.HeroOpts.Remove(heroOpt);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}