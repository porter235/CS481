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
    public class ForumPostsController : Controller
    {
        private db5a2eb9b6e7614a45b937a98b012d7edbEntities db = new db5a2eb9b6e7614a45b937a98b012d7edbEntities();

        // GET: ForumPosts
        public ActionResult Index()
        {
            var forumPosts = db.ForumPosts.Include(f => f.User);
            return View(forumPosts.ToList());
        }

        // GET: ForumPosts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumPost forumPost = db.ForumPosts.Find(id);
            if (forumPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = id;
            return View(forumPost);
        }

        // GET: ForumPosts/Create
        public ActionResult Create()
        {
            ViewBag.userID = new SelectList(db.Users, "userId", "fName");
            return View();
        }

        // POST: ForumPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "postID,title,content,timeCreate,score,userID")] ForumPost forumPost)
        {
            if (ModelState.IsValid)
            {
                db.ForumPosts.Add(forumPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userID = new SelectList(db.Users, "userId", "fName", forumPost.userID);
            return View(forumPost);
        }

        // GET: ForumPosts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumPost forumPost = db.ForumPosts.Find(id);
            if (forumPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.userID = new SelectList(db.Users, "userId", "fName", forumPost.userID);
            return View(forumPost);
        }

        // POST: ForumPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "postID,title,content,timeCreate,score,userID")] ForumPost forumPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.Users, "userId", "fName", forumPost.userID);
            return View(forumPost);
        }

        // GET: ForumPosts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumPost forumPost = db.ForumPosts.Find(id);
            if (forumPost == null)
            {
                return HttpNotFound();
            }
            return View(forumPost);
        }

        // POST: ForumPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ForumPost forumPost = db.ForumPosts.Find(id);
            db.ForumPosts.Remove(forumPost);
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
