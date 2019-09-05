using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Abantwana_DayCare.Models;
using Abantwana_DayCare.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Abantwana_DayCare.Controllers
{
    public class StaffsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;

		public StaffsController()
		{
		}

		public StaffsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		public ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
			}
			private set
			{
				_signInManager = value;
			}
		}

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}


		// GET: Staffs
		public ActionResult Index()
        {
            return View(db.StaffMembers.ToList());
        }

        // GET: Staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffMember staffMember = db.StaffMembers.Find(id);
            if (staffMember == null)
            {
                return HttpNotFound();
            }
            return View(staffMember);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffId,FirstName,LastName,Email,phone,ID_Number,address,Picture,qualification,Number_Of_Work,Previous_Company,Prev_CompanyPhone,Password,ConfirmPassword")] StaffCreateVM model, HttpPostedFileBase img_upload)
        {
            if (ModelState.IsValid)
            {

				byte[] data = null;
				data = new byte[img_upload.ContentLength];
				img_upload.InputStream.Read(data, 0, img_upload.ContentLength);

				var user = new ApplicationUser { FullName = model.FirstName + " " + model.LastName, Id = model.ID_Number, UserName = model.FirstName + " " + model.LastName, Email = model.Email };
				var staff = new StaffMember { StaffId = model.generateID(), FirstName = model.FirstName, Email = model.Email, LastName = model.LastName, phone = model.phone, ID_Number = model.ID_Number, address = model.address, qualification = model.qualification, Previous_Company = model.Previous_Company, Number_Of_Work = model.Number_Of_Work, Prev_CompanyPhone = model.Prev_CompanyPhone,Picture=data };
				var result = UserManager.Create(user, model.Password);
				db.StaffMembers.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffMember staffMember = db.StaffMembers.Find(id);
            if (staffMember == null)
            {
                return HttpNotFound();
            }
            return View(staffMember);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffId,FirstName,LastName,Email,phone,ID_Number,address,Picture,qualification,Number_Of_Work,Previous_Company,Prev_CompanyPhone")] StaffMember staffMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staffMember);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffMember staffMember = db.StaffMembers.Find(id);
            if (staffMember == null)
            {
                return HttpNotFound();
            }
            return View(staffMember);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffMember staffMember = db.StaffMembers.Find(id);
            db.StaffMembers.Remove(staffMember);
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
