using RroleApp.Areas.CommentsArea.Models;
using RroleApp.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace RroleApp.Areas.CommentsArea.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var comments = db.CommentModels.Include(p => p.ApplicationUsers);
            return View(comments.ToList());
        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModel comment = db.CommentModels.Include(p => p.ApplicationUsers).FirstOrDefault(x => x.CommentModelId==id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public ActionResult Create(CommentModel commentModel)
        {
            var userName = User.Identity.Name;
            var author = db.Users.SingleOrDefault(x => x.UserName == userName);

            CommentModel newcComment = new CommentModel();

            newcComment.ApplicationUsers = author;
            newcComment.CommentText = commentModel.CommentText;

            db.CommentModels.Add(newcComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}