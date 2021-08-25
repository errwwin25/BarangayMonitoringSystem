using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarangayMonitoringSystem.Models;
namespace BarangayMonitoringSystem.Controllers
{
    public class HomeController : Controller
    {
        private BarangayMonitoringSystemContext db = new BarangayMonitoringSystemContext();


        public ActionResult Login1()
        {
            return View();
        }

     
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Stats = db.ResidentRegisters.Count();
            ViewBag.incidentstats = db.Blotterreports.Count();

            int countvoters = (from row in db.Clearances
                               where row.RegisteredVoter == "Yes"
                               select row).Count();

            ViewBag.voters = countvoters;

            int countemployed = (from row in db.ResidentRegisters
                               where row.Occupation != "Unemployed"
                               select row).Count();

            ViewBag.employed = countemployed;

            int countunemployed = (from row in db.ResidentRegisters
                                 where row.Occupation == "Unemployed"
                                 select row).Count();

            ViewBag.unemployed = countunemployed;

            ViewBag.voters = countvoters;

            ViewBag.clearedstats = db.Clearances.Count();

            int countmale = (from row in db.ResidentRegisters
                                   where row.Gender == "Male"
                                   select row).Count();

            ViewBag.males = countmale;


            int countfemale = (from row in db.ResidentRegisters
                             where row.Gender == "Female"
                             select row).Count();

            ViewBag.females = countfemale;
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

        public ActionResult Developersite()
        {
            ViewBag.Message = "Developer Info.";

            return View();
        }

       
    }
}