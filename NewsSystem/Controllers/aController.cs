//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using NewsSystem.Data;

//namespace NewsSystem.Controllers
//{
//    public class aController : Controller
//    {
//        private NewsSystemContext db = new NewsSystemContext();

//        // GET: a
//        public ActionResult Index()
//        {
//            var a = db.a.Include(a => a.Author).Include(a => a.Category);
//            return View(a.ToList());
//        }

//        // GET: a/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            a a = db.a.Find(id);
//            if (a == null)
//            {
//                return HttpNotFound();
//            }
//            return View(a);
//        }

//        // GET: a/Create
//        public ActionResult Create()
//        {

//            return View();
//        }

//        // POST: a/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "ArticleId,Title,Content,CreationDate,AuthorId,CategoryId")] a a)
//        {
//            if (ModelState.IsValid)
//            {
//                db.a.Add(a);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Email", a.AuthorId);
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", a.CategoryId);
//            return View(a);
//        }

//        // GET: a/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            a a = db.a.Find(id);
//            if (a == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Email", a.AuthorId);
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", a.CategoryId);
//            return View(a);
//        }

//        // POST: a/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ArticleId,Title,Content,CreationDate,AuthorId,CategoryId")] a a)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(a).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Email", a.AuthorId);
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", a.CategoryId);
//            return View(a);
//        }

//        // GET: a/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            a a = db.a.Find(id);
//            if (a == null)
//            {
//                return HttpNotFound();
//            }
//            return View(a);
//        }

//        // POST: a/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            a a = db.a.Find(id);
//            db.a.Remove(a);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
