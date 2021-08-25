using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Common;
using BarangayMonitoringSystem.ViewModels;
using BarangayMonitoringSystem.Models;

namespace BarangayMonitoringSystem.Controllers
{
    public class ClearancesController : Controller
    {
        private BarangayMonitoringSystemContext db = new BarangayMonitoringSystemContext();

        // GET: Clearances
        public ActionResult Index()
        {
            var tables = new ClearanceResidentsViewModel
            {
                resident = db.ResidentRegisters.ToList(),
                incidents = db.Blotterreports.ToList(),
                documentsclearances = db.Clearances.ToList()
            };


            return View(tables);
        }

        // GET: Clearances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clearances clearances = db.Clearances.Find(id);
            if (clearances == null)
            {
                return HttpNotFound();
            }
            return View(clearances);
        }

        // GET: Clearances/Create
        public ActionResult Create()
        {
            ResidentViewModels models = new ResidentViewModels();
            models.ResidentList = new SelectList(db.ResidentRegisters, "ID", "FullName");
            ViewBag.mySelectList = models.ResidentList;
            return View(models);
        }

        // POST: Clearances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = " fullname, documents, ResidentList ")] ResidentViewModels documentissuance)
        {
            if (ModelState.IsValid)
            {
                documentissuance.ResidentList = new SelectList(db.ResidentRegisters, "ID", "FullName", 1);
                  

                db.Clearances.Add(documentissuance.documents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            documentissuance.ResidentList = new SelectList(db.ResidentRegisters, "ID", "FullName", 1);

            ViewBag.mySelectList = documentissuance.ResidentList;

            return View(documentissuance);
        }

        // GET: Clearances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clearances clearances = db.Clearances.Find(id);
            if (clearances == null)
            {
                return HttpNotFound();
            }
            return View(clearances);
        }

        // POST: Clearances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClearanceId,ResidentId,Residentname,Cedula,BarangayId,RegisteredVoter,BGClearance")] Clearances clearances)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clearances).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clearances);
        }

        // GET: Clearances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clearances clearances = db.Clearances.Find(id);
            if (clearances == null)
            {
                return HttpNotFound();
            }
            return View(clearances);
        }

        // POST: Clearances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clearances clearances = db.Clearances.Find(id);
            db.Clearances.Remove(clearances);
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

        // GET: Clearances/Details/
        public ActionResult Certificaterequest(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clearances clearances = db.Clearances.Find(id);
            if (clearances == null)
            {
                return HttpNotFound();
            }
            return View(clearances);
        }

        public ActionResult Clearancerequest(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clearances clearances = db.Clearances.Find(id);
            if (clearances == null)
            {
                return HttpNotFound();
            }
            return View(clearances);
        }

        public ActionResult getclearance([Bind(Include = "ClearanceId,ResidentId,Residentname,Cedula,BarangayId,RegisteredVoter,BGClearance")] Clearances clearances)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clearances).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clearances);
        }
    }
}
