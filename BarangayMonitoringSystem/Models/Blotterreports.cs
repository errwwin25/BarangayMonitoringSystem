using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace BarangayMonitoringSystem.Models
{
    public class Blotterreports
    {
        [Key]
        [Display(Name = "Blotter Number") Required]
        public int Blotternumber { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:2020-0000}")]
        [Display(Name = "Resident ID") ]
       
        public int Id { get; set; }


       
        [Display(Name = "Full Name")]
        public string FullName
        {
           
            get { return ResidentFirstName + " "+ ResidentMiddleName + " " + ResidentLastName; }

        }

        public Blotterreports()
        {
            this.Resident = new HashSet<ResidentRegister>();
        }

        public virtual ICollection<ResidentRegister> Resident { get; set; }

        [Display(Name = "First Name") ]
        public string ResidentFirstName { get; set; }


        [Display(Name = "Middle Name")]
        public string ResidentMiddleName { get; set; }

        [Display(Name = "Last Name") ]
        public string ResidentLastName { get; set; }

        [Display(Name = "Incident Location") Required]
        public string Incidentlocation { get; set; }

        [Display(Name = "Incident Type") Required]
        public string Incidenttype { get; set; }

        [Display(Name = "Status") Required]
        public string Status { get; set; }

        public string Remarks { get; set; }


        private DateTime incidentlogged = DateTime.Now;
  
       
        [DataType(DataType.Date)]
        [Display(Name = "Date Reported") Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Datereported
        {            get;    set;         }
        




        [Display(Name = "Date of Incident") Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime DateIncident { get; set; }


    }
}