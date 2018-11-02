using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS481.Models;

namespace CS481.Controllers
{
    public class ForumCommentsController : Controller
    {
        private db5a2eb9b6e7614a45b937a98b012d7edbEntities db = new db5a2eb9b6e7614a45b937a98b012d7edbEntities();

        // GET: ForumComments
        public ActionResult Index()
        {
            var forumComments = db.ForumComments.Include(f => f.ForumPost);
            return View(forumComments.ToList());
        }

        // GET: ForumComments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumComment forumComment = db.ForumComments.Find(id);
            if (forumComment == null)
            {
                return HttpNotFound();
            }
            return View(forumComment);
        }

        // GET: ForumComments/Create
        public ActionResult Create()
        {
            ViewBag.postID = new SelectList(db.ForumPosts, "postID", "title");
            return View();
        }

        // POST: ForumComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "commentID,content,timeCreate,score,userID,postID")] ForumComment forumComment)
        {
            if (ModelState.IsValid)
            {
                db.ForumComments.Add(forumComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.postID = new SelectList(db.ForumPosts, "postID", "title", forumComment.postID);
            return View(forumComment);
        }

        // GET: ForumComments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumComment forumComment = db.ForumComments.Find(id);
            if (forumComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.postID = new SelectList(db.ForumPosts, "postID", "title", forumComment.postID);
            return View(forumComment);
        }

        // POST: ForumComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "commentID,content,timeCreate,score,userID,postID")] ForumComment forumComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.postID = new SelectList(db.ForumPosts, "postID", "title", forumComment.postID);
            return View(forumComment);
        }

        // GET: ForumComments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumComment forumComment = db.ForumComments.Find(id);
            if (forumComment == null)
            {
                return HttpNotFound();
            }
            return View(forumComment);
        }

        // POST: ForumComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ForumComment forumComment = db.ForumComments.Find(id);
            db.ForumComments.Remove(forumComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
