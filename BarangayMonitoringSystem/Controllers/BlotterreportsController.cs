using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using PagedList;
using BarangayMonitoringSystem.Models;
using BarangayMonitoringSystem.ViewModels;

namespace BarangayMonitoringSystem.Controllers
{
    public class BlotterreportsController : Controller
    {
        private BarangayMonitoringSystemContext db = new BarangayMonitoringSystemContext();

        // GET: Blotterreports
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewBag.MiddleNameSortParm = String.IsNullOrEmpty(sortOrder) ? "middlename_desc" : "";
            ViewBag.IncSortParm = String.IsNullOrEmpty(sortOrder) ? "inc_desc" : "";
            ViewBag.StatusSortParm = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.LocationSortParm = String.IsNullOrEmpty(sortOrder) ? "inc_loc_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var incidents = from s in db.Blotterreports
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                incidents = incidents.Where(s => s.ResidentLastName.Contains(searchString)
                                       || s.ResidentFirstName.Contains(searchString)
                                        || s.ResidentMiddleName.Contains(searchString)
                                                                       
                                       || s.Status.Contains(searchString)
                                       || s.Remarks.Contains(searchString)
                                       || s.Incidentlocation.Contains(searchString)
                                       || s.Incidenttype.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "lastname":
                    incidents = incidents.OrderBy(s => s.ResidentLastName);
                    break;
                case "lastname_desc":
                    incidents = incidents.OrderByDescending(s => s.ResidentLastName);
                    break;
                case "firstname":
                    incidents = incidents.OrderBy(s => s.ResidentFirstName);
                    break;
                case "firstname_desc":
                    incidents = incidents.OrderByDescending(s => s.ResidentFirstName);
                    break;
                case "middlename":
                    incidents = incidents.OrderBy(s => s.ResidentMiddleName);
                    break;
                case "middlename_desc":
                    incidents = incidents.OrderByDescending(s => s.ResidentMiddleName);
                    break;
                case "type":
                    incidents = incidents.OrderBy(s => s.Incidenttype);
                    break;
                case "type_desc":
                    incidents = incidents.OrderByDescending(s => s.Incidenttype);
                    break;
                case "location":
                    incidents = incidents.OrderBy(s => s.Incidentlocation);
                    break;
                case "location_desc":
                    incidents = incidents.OrderByDescending(s => s.Incidentlocation);
                    break;
                case "datereported":
                    incidents = incidents.OrderBy(s => s.Incidentlocation);
                    break;
                case "datereported_desc":
                    incidents = incidents.OrderByDescending(s => s.Incidentlocation);
                    break;


                default:
                    incidents = incidents.OrderBy(s => s.Id);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(incidents.ToPagedList(pageNumber, pageSize));
        }

        // GET: Blotterreports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blotterreports blotterreports = db.Blotterreports.Find(id);
            if (blotterreports == null)
            {
                return HttpNotFound();
            }
            return View(blotterreports);
        }

        // GET: Blotterreports/Create
        public ActionResult Create()
        {
            ResidentViewModels models = new ResidentViewModels();
            models.ResidentList = new SelectList(db.ResidentRegisters, "ID", "FullName");

            return View(models);
        }

        // POST: Blotterreports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "incidents, ResidentList ")] ResidentViewModels inc_report)
        {
           

            if (ModelState.IsValid)
            {

                inc_report.ResidentList = new SelectList(db.ResidentRegisters, "ID", "FullName", 1);

                db.Blotterreports.Add(inc_report.incidents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            inc_report.ResidentList = new SelectList(db.ResidentRegisters, "ID", "FullName", 1) ;

            return View(inc_report); 
        }

        // GET: Blotterreports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blotterreports blotterreports = db.Blotterreports.Find(id);
            if (blotterreports == null)
            {
                return HttpNotFound();
            }
            return View(blotterreports);
        }

        // POST: Blotterreports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Blotternumber,Id,ResidentFirstName,ResidentMiddleName,ResidentLastName,Incidentlocation,Incidenttype,Status,Remarks,Datereported,DateIncident")] Blotterreports blotterreports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blotterreports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blotterreports);
        }

        // GET: Blotterreports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blotterreports blotterreports = db.Blotterreports.Find(id);
            if (blotterreports == null)
            {
                return HttpNotFound();
            }
            return View(blotterreports);
        }

        // POST: Blotterreports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blotterreports blotterreports = db.Blotterreports.Find(id);
            db.Blotterreports.Remove(blotterreports);
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
