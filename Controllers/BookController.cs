using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private librarydbEntities db = new librarydbEntities();

        // GET: Book
        public ActionResult Index()
        {
            var books = db.books.Include(b => b.author).Include(b => b.category).Include(b => b.publisher);
            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.author_id = new SelectList(db.authors, "id", "name");
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name");
            ViewBag.publisher_id = new SelectList(db.publishers, "id", "name");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,book_name,category_id,author_id,publisher_id,contents,pages,edition")] book book)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.author_id = new SelectList(db.authors, "id", "name", book.author_id);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", book.category_id);
            ViewBag.publisher_id = new SelectList(db.publishers, "id", "name", book.publisher_id);
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.author_id = new SelectList(db.authors, "id", "name", book.author_id);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", book.category_id);
            ViewBag.publisher_id = new SelectList(db.publishers, "id", "name", book.publisher_id);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,book_name,category_id,author_id,publisher_id,contents,pages,edition")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.author_id = new SelectList(db.authors, "id", "name", book.author_id);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", book.category_id);
            ViewBag.publisher_id = new SelectList(db.publishers, "id", "name", book.publisher_id);
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.books.Find(id);
            db.books.Remove(book);
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
