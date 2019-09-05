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
    public class LearningController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Learning
        public ActionResult Index()
        {
            return View(db.Learning_Material.ToList());
        }

        // GET: Learning/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Learning_Material learning_Material = db.Learning_Material.Find(id);
            if (learning_Material == null)
            {
                return HttpNotFound();
            }
            return View(learning_Material);
        }

        // GET: Learning/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Learning/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Material_ID,material,Description")] Learning_Material learning_Material, HttpPostedFileBase img_upload)
        {
            if (ModelState.IsValid)
            {
				byte[] data = null;
				data = new byte[img_upload.ContentLength];
				img_upload.InputStream.Read(data, 0, img_upload.ContentLength);

				learning_Material.material = data;
				db.Learning_Material.Add(learning_Material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(learning_Material);
        }

        // GET: Learning/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Learning_Material learning_Material = db.Learning_Material.Find(id);
            if (learning_Material == null)
            {
                return HttpNotFound();
            }
            return View(learning_Material);
        }

        // POST: Learning/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Material_ID,material,Description")] Learning_Material learning_Material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(learning_Material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(learning_Material);
        }

        // GET: Learning/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Learning_Material learning_Material = db.Learning_Material.Find(id);
            if (learning_Material == null)
            {
                return HttpNotFound();
            }
            return View(learning_Material);
        }

        // POST: Learning/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Learning_Material learning_Material = db.Learning_Material.Find(id);
            db.Learning_Material.Remove(learning_Material);
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
