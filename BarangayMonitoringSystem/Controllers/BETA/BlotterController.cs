using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using BarangayMonitoringSystem.Models;
namespace BarangayMonitoringSystem.Controllers
{
    public class BlotterController : Controller
    {
        // GET: Blotter
        public ActionResult Blotter()
        {

            ViewBag.Blotterreports = "Reported Incidents";

            List<Blotterreports> brgyblotter = new List<Blotterreports>()
            {

                  new Blotterreports {Blotternumber = 1, ResidentFirstName = "Kirvy",
                     Incidentlocation = "Sapang Bato",
                     Incidenttype = "Breach", Status = "Pending", Remarks = "Lost of human life is tragic, even subhuman life",
                      Datereported = DateTime.Parse("04'/05'/2020"), DateIncident = DateTime.Parse( "04'/4'/2020 5:00PM")},

                  new Blotterreports {Blotternumber = 2, ResidentFirstName = "Erwin",
                    Incidentlocation = "City Center",
                     Incidenttype = "Jaywalking", Status = "Resolved", Remarks = "Lost of human life is tragic, even subhuman life",
                     Datereported = DateTime.Parse("04'/09'/2020"), DateIncident = DateTime.Parse("04'/08'/2020 1:00PM")},
            };
            return View(brgyblotter);
        }
    }
}