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
    public class QuizesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quizes
        public ActionResult Index()
        {
            var quizs = db.Quizs.Include(q => q.Learning);
            return View(quizs.ToList());
        }

        // GET: Quizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.Quizs.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: Quizes/Create
        public ActionResult Create()
        {
            ViewBag.Learning_ID = new SelectList(db.Learning_Material, "Material_ID", "Description");
            return View();
        }

        // POST: Quizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Quiz_ID,Question,Answer,A,B,C,D,Learning_ID")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Quizs.Add(quiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Learning_ID = new SelectList(db.Learning_Material, "Material_ID", "Description", quiz.Learning_ID);
            return View(quiz);
        }
		public ActionResult Take_Quiz()
		{
			var quizs = db.Quizs.Include(q => q.Learning);
			return View(quizs.ToList());
		}




        // GET: Quizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.Quizs.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            ViewBag.Learning_ID = new SelectList(db.Learning_Material, "Material_ID", "Description", quiz.Learning_ID);
            return View(quiz);
        }

        // POST: Quizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Quiz_ID,Question,Answer,A,B,C,D,Learning_ID")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Learning_ID = new SelectList(db.Learning_Material, "Material_ID", "Description", quiz.Learning_ID);
            return View(quiz);
        }

        // GET: Quizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.Quizs.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quiz quiz = db.Quizs.Find(id);
            db.Quizs.Remove(quiz);
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
