using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eFilling_KP_V2;
using eFilling_KP_V2.Models;
using Microsoft.AspNet.Identity;

namespace eFilling_KP_V2.Controllers
{
    public class DocumentLettersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DocumentLetters
        public ActionResult Index()
        {
            return View(db.DocumentLetters.ToList());
        }

        // GET: DocumentLetters/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentLetter documentLetter = db.DocumentLetters.Find(id);
            if (documentLetter == null)
            {
                return HttpNotFound();
            }
            return View(documentLetter);
        }

        // GET: DocumentLetters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentLetters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Document_Created_By_ID,Number,Document_From,Origin_Agency,Title,Content,Created_Date")] DocumentLetter documentLetter)
        {
            if (ModelState.IsValid)
            {
                documentLetter.ID = Guid.NewGuid();
                documentLetter.Document_Created_By_ID = User.Identity.GetUserId();
                documentLetter.Created_Date = DateTime.Now;

                db.DocumentLetters.Add(documentLetter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(documentLetter);
        }

        // GET: DocumentLetters/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentLetter documentLetter = db.DocumentLetters.Find(id);
            if (documentLetter == null)
            {
                return HttpNotFound();
            }
            return View(documentLetter);
        }

        // POST: DocumentLetters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Document_Created_By_ID,Number,Document_From,Origin_Agency,Title,Content,Created_Date")] DocumentLetter documentLetter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentLetter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documentLetter);
        }

        // GET: DocumentLetters/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentLetter documentLetter = db.DocumentLetters.Find(id);
            if (documentLetter == null)
            {
                return HttpNotFound();
            }
            return View(documentLetter);
        }

        // POST: DocumentLetters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DocumentLetter documentLetter = db.DocumentLetters.Find(id);
            db.DocumentLetters.Remove(documentLetter);
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
