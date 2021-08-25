using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarangayMonitoringSystem.Models;
namespace BarangayMonitoringSystem.Controllers
{
      public class ResidentController : Controller
    {
        // GET: Resident
          public ActionResult Resident()
        {

            ViewBag.ResidentRegister = "Registered Residents";
            
         List<ResidentRegister> ResidentList = new List<ResidentRegister>()
            {
               new ResidentRegister {ID = 1, ResidentFirstName = "Recy", Gender = "Female",
                     ResidentLastName ="Dequiros", ResidentMiddleName = "C.",
                     Age = 19, Address = "Caloocan", Birthdate = DateTime.Parse("May,20,2000"), Contactnumber = "0999999",
                      Status = "Single", Nationality = "Filipino", Religion = "Catholic" , Occupation = "Student", PlaceofBirth = "Caloocan"},

                new ResidentRegister {ID = 2, ResidentFirstName = "Kaila", Contactnumber = "0999999", Gender = "Female",
                    ResidentLastName ="David",  ResidentMiddleName = "Ariza", Age = 20, Address = "Sindalan", Birthdate = DateTime.Parse("Septober/12/1999"),
                     Status = "In a Relationship", Nationality = "Filipino", Religion = "Catholic", Occupation = "Student" , PlaceofBirth = "San Fernando"},

                new ResidentRegister {ID = 3, ResidentFirstName = "John", Contactnumber = "0999999", Gender = "Male",
                    ResidentLastName ="Doe", ResidentMiddleName = "Smith", Age = 25, Address = "Angeles City", Birthdate = DateTime.Parse("Decembary/6/1995"),
                     Status = "Single", Nationality = "Filipino", Religion = "Catholic" , Occupation = "Teacher" , PlaceofBirth = "Sto.Cristo"},

                new ResidentRegister {ID = 4, ResidentFirstName = "Erwin", Contactnumber = "0999999", Gender = "Male",
                    ResidentLastName = "Galura",  ResidentMiddleName = "M.", Age = 19, Address = "Pandan", Birthdate = DateTime.Parse("May/10/2000"),
                     Status = "Single", Nationality = "Filipino", Religion = "Catholic", Occupation = "Student" , PlaceofBirth = "Pampanga" },

                   new ResidentRegister {ID = 5, ResidentFirstName = "Covid", Contactnumber = "0999999",  Gender = "Male",
                    ResidentLastName ="Mers",  ResidentMiddleName = "Bryant", Age = 19, Address = "China", Birthdate = DateTime.Parse("March /20/2020"),
                     Status = "Single", Nationality = "Chinese", Religion = "Catholic" , Occupation = "Doctor", PlaceofBirth = "Wuhan" },
            };
            return View(ResidentList);
        }
        public ActionResult Viewresidents()
        {
            ViewBag.Message = "Resident Info.";

            List<ResidentRegister> ResidentList = new List<ResidentRegister>()
            {
                  new ResidentRegister {ID = 1, ResidentFirstName = "Recy", Gender = "Female",
                     ResidentLastName ="Dequiros", ResidentMiddleName = "C.",
                     Age = 19, Address = "Caloocan", Birthdate = DateTime.Parse("May,20,2000"), Contactnumber = "0999999",
                      Status = "Single", Nationality = "Filipino", Religion = "Catholic" , Occupation = "Student", PlaceofBirth = "Caloocan"},

                new ResidentRegister {ID = 2, ResidentFirstName = "Kaila", Contactnumber = "0999999", Gender = "Female",
                    ResidentLastName ="David",  ResidentMiddleName = "Ariza", Age = 20, Address = "Sindalan", Birthdate = DateTime.Parse("Septober/12/1999"),
                     Status = "In a Relationship", Nationality = "Filipino", Religion = "Catholic", Occupation = "Student" , PlaceofBirth = "San Fernando"},

                new ResidentRegister {ID = 3, ResidentFirstName = "John", Contactnumber = "0999999", Gender = "Male",
                    ResidentLastName ="Doe", ResidentMiddleName = "Smith", Age = 25, Address = "Angeles City", Birthdate = DateTime.Parse("Decembary/6/1995"),
                     Status = "Single", Nationality = "Filipino", Religion = "Catholic" , Occupation = "Teacher" , PlaceofBirth = "Sto.Cristo"},

                new ResidentRegister {ID = 4, ResidentFirstName = "Erwin", Contactnumber = "0999999", Gender = "Male",
                    ResidentLastName = "Galura",  ResidentMiddleName = "M.", Age = 19, Address = "Pandan", Birthdate = DateTime.Parse("May/10/2000"),
                     Status = "Single", Nationality = "Filipino", Religion = "Catholic", Occupation = "Student" , PlaceofBirth = "Pampanga" },

                   new ResidentRegister {ID = 5, ResidentFirstName = "Covid", Contactnumber = "0999999",  Gender = "Male",
                    ResidentLastName ="Mers",  ResidentMiddleName = "Bryant", Age = 19, Address = "China", Birthdate = DateTime.Parse("March /20/2020"),
                     Status = "Single", Nationality = "Chinese", Religion = "Catholic" , Occupation = "Doctor", PlaceofBirth = "Wuhan" },
            };
            return View(ResidentList);
        }
    }
}