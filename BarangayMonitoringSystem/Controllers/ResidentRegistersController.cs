using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BarangayMonitoringSystem.Models;

namespace BarangayMonitoringSystem.Controllers
{
    public class ResidentRegistersController : Controller
    {
        private BarangayMonitoringSystemContext db = new BarangayMonitoringSystemContext();

        // GET: ResidentRegisters
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewBag.MiddleNameSortParm = String.IsNullOrEmpty(sortOrder) ? "middlename_desc" : "";
            ViewBag.AgeSortParm = sortOrder == "Age" ? "age_desc" : "Age";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.GenderSortParm = String.IsNullOrEmpty(sortOrder) ? "gender_desc" : "";
            ViewBag.StatusSortParm = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewBag.AddressSortParm = String.IsNullOrEmpty(sortOrder) ? "address_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var residents = from s in db.ResidentRegisters
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                residents = residents.Where(s => s.ResidentLastName.Contains(searchString)
                                       || s.ResidentFirstName.Contains(searchString)
                                       || s.ResidentMiddleName.Contains(searchString)
                                       //|| s.Birthdate.CompareTo(searchString) 
                                       ||s.Address.Contains(searchString)
                                       || s.Nationality.Contains(searchString)
                                       || s.Religion.Contains(searchString)
                                       || s.Status.Contains(searchString)
                                       || s.ResidentFirstName.Contains(searchString)
                                       || s.Occupation.Contains(searchString)
                                      
                                       || s.Gender.StartsWith(searchString));
            }
            switch (sortOrder)
            {
                case "lastname":
                    residents = residents.OrderBy(s => s.ResidentLastName);
                    break;
                case "lastname_desc":
                    residents = residents.OrderByDescending(s => s.ResidentLastName);
                    break;
                case "Date":
                    residents = residents.OrderBy(s => s.Birthdate);
                    break;
                case "date_desc":
                    residents = residents.OrderByDescending(s => s.Birthdate);
                    break;
                case "firstname":
                    residents = residents.OrderBy(s => s.ResidentFirstName);
                    break;
                case "firstname_desc":
                    residents = residents.OrderByDescending(s => s.ResidentFirstName);
                    break;
                case "middlename":
                    residents = residents.OrderBy(s => s.ResidentMiddleName);
                    break;
                case "middlename_desc":
                    residents = residents.OrderByDescending(s => s.ResidentMiddleName);
                    break;
                case "age":
                    residents = residents.OrderBy(s => s.Age);
                    break;
                case "age_desc":
                    residents = residents.OrderByDescending(s => s.Age);
                    break;
                case "gender":
                    residents = residents.OrderBy(s => s.Gender);
                    break;
                case "gender_desc":
                    residents = residents.OrderByDescending(s => s.Gender);
                    break;
                case "status":
                    residents = residents.OrderBy(s => s.Status);
                    break;
                case "status_desc":
                    residents = residents.OrderByDescending(s => s.Status);
                     break;
                case "address":
                    residents = residents.OrderBy(s => s.Address);
                    break;
                case "address_desc":
                    residents = residents.OrderByDescending(s => s.Address);
                    break;
                case "religion":
                    residents = residents.OrderBy(s => s.Religion);
                    break;
                case "religion_desc":
                    residents = residents.OrderByDescending(s => s.Religion);
                    break;
                case "occupation":
                    residents = residents.OrderBy(s => s.Occupation);
                    break;
                case "occupation_desc":
                    residents = residents.OrderByDescending(s => s.Occupation);
                    break;
                case "nationality":
                    residents = residents.OrderBy(s => s.Nationality);
                    break;
                case "nationality_desc":
                    residents = residents.OrderByDescending(s => s.Nationality);
                    break;
                case "placeofbirth":
                    residents = residents.OrderBy(s => s.PlaceofBirth);
                    break;
                case "placeofbirth_desc":
                    residents = residents.OrderByDescending(s => s.PlaceofBirth);
                    break;
                case "contactnumber":
                    residents = residents.OrderBy(s => s.Contactnumber);
                    break;
                case "contactnumber_desc":
                    residents = residents.OrderByDescending(s => s.Contactnumber);
                    break;
                default:
                    residents = residents.OrderBy(s => s.ID);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(residents.ToPagedList(pageNumber, pageSize));
        }


        // GET: ResidentRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentRegister residentRegister = db.ResidentRegisters.Find(id);
            if (residentRegister == null)
            {
                return HttpNotFound();
            }
            return View(residentRegister);
        }

        // GET: ResidentRegisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResidentRegisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ResidentFirstName,ResidentMiddleName,ResidentLastName,Age,Address, Gender, Religion,Status,Occupation,Nationality,Birthdate,PlaceofBirth, Contactnumber")] ResidentRegister residentRegister)
        {
            if (ModelState.IsValid)
            {
                db.ResidentRegisters.Add(residentRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(residentRegister);
        }

        // GET: ResidentRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentRegister residentRegister = db.ResidentRegisters.Find(id);
            if (residentRegister == null)
            {
                return HttpNotFound();
            }
            return View(residentRegister);
        }

        // POST: ResidentRegisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ResidentFirstName,ResidentMiddleName,ResidentLastName,Age, Gender, Address,Religion,Status,Occupation,Nationality,Birthdate,PlaceofBirth,Contactnumber")] ResidentRegister residentRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(residentRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(residentRegister);
        }

        // GET: ResidentRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentRegister residentRegister = db.ResidentRegisters.Find(id);
            if (residentRegister == null)
            {
                return HttpNotFound();
            }
            return View(residentRegister);
        }

        // POST: ResidentRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResidentRegister residentRegister = db.ResidentRegisters.Find(id);
            db.ResidentRegisters.Remove(residentRegister);
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
