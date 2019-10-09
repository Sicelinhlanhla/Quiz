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
    public class ParentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;

		public ParentsController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
		{
			UserManager = userManager;
			RoleManager = roleManager;
		}

		public ParentsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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


		private ApplicationRoleManager _roleManager;
		public ApplicationRoleManager RoleManager
		{
			get
			{
				return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
			}
			private set
			{
				_roleManager = value;
			}
		}


		// GET: Parents
		public ActionResult Index()
        {
            return View(db.Parent_Model.ToList());
        }

        // GET: Parents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent_Model parent_Model = db.Parent_Model.Find(id);
            if (parent_Model == null)
            {
                return HttpNotFound();
            }
            return View(parent_Model);
        }

        // GET: Parents/Create
        public ActionResult Create()
        {

			ViewBag.RoleId = new SelectList( RoleManager.Roles.ToList(), "Name", "Name");

			return View();
        }

        // POST: Parents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Parent_Id,FirstName,LastName,Email,phone,ID_Number,address,DOB,Work_Place,CompanyPhone,relationship,Password,ConfirmPassword")] ParentCreateVM model)
        {
            if (ModelState.IsValid)
            {

				var user = new ApplicationUser { FullName = model.FirstName + " " + model.LastName, Id = model.ID_Number, UserName = model.FirstName + " " + model.LastName, Email = model.Email };
				var parent = new Parent_Model { Parent_Id= model.generateID(), FirstName = model.FirstName, Email=model.Email,LastName = model.LastName,phone=model.phone, ID_Number = model.ID_Number, address = model.address, DOB = model.DOB, Work_Place = model.Work_Place, CompanyPhone = model.CompanyPhone, relationship = model.relationship };
				var result = UserManager.Create(user, model.Password);
				if (result.Succeeded)
				{
					
						var Roleresult =  UserManager.AddToRolesAsync(user.Id, "Parent");
						if (!result.Succeeded)
						{
							ModelState.AddModelError("", result.Errors.First());
							ViewBag.RoleId = new SelectList(RoleManager.Roles.ToList(), "Name", "Name");
							return View();
						}
					}

				db.Parent_Model.Add(parent);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(model);
		}

            
        

        // GET: Parents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent_Model parent_Model = db.Parent_Model.Find(id);
            if (parent_Model == null)
            {
                return HttpNotFound();
            }
            return View(parent_Model);
        }

        // POST: Parents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Parent_Id,FirstName,LastName,Email,phone,ID_Number,address,DOB,Work_Place,CompanyPhone,relationship")] Parent_Model parent_Model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parent_Model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parent_Model);
        }

        // GET: Parents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent_Model parent_Model = db.Parent_Model.Find(id);
            if (parent_Model == null)
            {
                return HttpNotFound();
            }
            return View(parent_Model);
        }

        // POST: Parents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parent_Model parent_Model = db.Parent_Model.Find(id);
            db.Parent_Model.Remove(parent_Model);
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
