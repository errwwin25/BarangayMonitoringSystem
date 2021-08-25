using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarangayMonitoringSystem.Models
{
    public class Clearances
    {
        [Key]
        [Display(Name = "Clearance Id")]
        public int ClearanceId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:2020-0000}")]
        [Display(Name = "Resident ID")]
        public int ResidentId { get; set; }

        [Display(Name = "Last Name")]
        public string Residentlastname { get; set; }

        [Display(Name = "Middle Name")]
        public string Residentmiddlename { get; set; }
        [Display(Name = "First Name")]
        public string Residentfirstname { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return Residentfirstname + " " + Residentmiddlename + " " + Residentlastname; }

        }

        public string Cedula { get; set; }

        [Display(Name = "Barangay ID")]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:2020-0000}")]
        public string  BarangayId { get; set; }

        [Display(Name = "Registered Voter")]
        public string RegisteredVoter { get; set; }

        [Display(Name = "Barangay Clearance")]
        public string BGClearance { get; set; }
    }
}