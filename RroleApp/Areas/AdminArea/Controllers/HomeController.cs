using Microsoft.AspNet.Identity;
using RroleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RroleApp.Areas.AdminArea.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            
            return View(db.Users.ToList());
        }
    }
}