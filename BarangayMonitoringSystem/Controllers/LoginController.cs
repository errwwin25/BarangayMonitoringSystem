using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarangayMonitoringSystem.Models;

namespace BarangayMonitoringSystem.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Login1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login1(Logindb login)
        {
            if (ModelState.IsValid)
            {
                BarangayMonitoringSystemContext db = new BarangayMonitoringSystemContext();
                var user = (from userlist in db.Logindbs
                            where userlist.UserName == login.UserName && userlist.Password == login.Password
                            select new
                            {
                                userlist.UserID,
                                userlist.UserName
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["UserName"] = user.FirstOrDefault().UserName;
                    Session["UserID"] = user.FirstOrDefault().UserID;
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.Wronglogin = "Invalid login credentials.";
                }
            }
            return View(login);
        }
    
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}