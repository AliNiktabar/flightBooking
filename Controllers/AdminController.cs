using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using flightbooking_project.Models;

namespace flightbooking_project.Controllers
{
    public class AdminController : Controller
    {
        ContextCS c = new ContextCS();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            if (Session["u"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Adminlogin(AdminLogin I)
        {
            var x = c.AdminLogins.Where(a => a.AdminName.Equals(I.AdminName) && a.AdminPassword.Equals(I.AdminPassword)).FirstOrDefault();
            if (x != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.m = "نام کاربری یا رمز عبور نادرست است.";
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }

     
    }

}