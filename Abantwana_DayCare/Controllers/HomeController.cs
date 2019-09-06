﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abantwana_DayCare.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (User.IsInRole("Admin"))
			{
				return View("Dashboard");

			}



			return View();
		}
		public ActionResult Dashboard()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}