using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Abantwana_DayCare.Models;

namespace Abantwana_DayCare.Controllers
{
    public class ToodlersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Toodlers
        public ActionResult Index()
        {
            var toodlers = db.Toodlers.Include(t => t.Parent);
            return View(toodlers.ToList());
        }

        // GET: Toodlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toodler toodler = db.Toodlers.Find(id);
            if (toodler == null)
            {
                return HttpNotFound();
            }
            return View(toodler);
        }

        // GET: Toodlers/Create
        public ActionResult Create()
        {
            ViewBag.Parent_ID = new SelectList(db.Parent_Model, "Parent_Id", "FirstName");
            return View();
        }

        // POST: Toodlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Toodler_ID,First_Name,Last_Name,ID_Number,Date_of_Birth,Parent_ID")] Toodler toodler)
        {
            if (ModelState.IsValid)
            {
                db.Toodlers.Add(toodler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Parent_ID = new SelectList(db.Parent_Model, "Parent_Id", "FirstName", toodler.Parent_ID);
            return View(toodler);
        }

        // GET: Toodlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toodler toodler = db.Toodlers.Find(id);
            if (toodler == null)
            {
                return HttpNotFound();
            }
            ViewBag.Parent_ID = new SelectList(db.Parent_Model, "Parent_Id", "FirstName", toodler.Parent_ID);
            return View(toodler);
        }

        // POST: Toodlers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Toodler_ID,First_Name,Last_Name,ID_Number,Date_of_Birth,Parent_ID")] Toodler toodler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toodler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Parent_ID = new SelectList(db.Parent_Model, "Parent_Id", "FirstName", toodler.Parent_ID);
            return View(toodler);
        }

        // GET: Toodlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toodler toodler = db.Toodlers.Find(id);
            if (toodler == null)
            {
                return HttpNotFound();
            }
            return View(toodler);
        }

        // POST: Toodlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Toodler toodler = db.Toodlers.Find(id);
            db.Toodlers.Remove(toodler);
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
