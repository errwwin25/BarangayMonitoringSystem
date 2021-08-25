using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PagedList;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarangayMonitoringSystem.Models
{
    public class ResidentRegister
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:2020-0000}")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [NotMapped]
        [Display(Name = "Resident")]
        public string FullName
        {
            get { return ID + ".)" + ResidentFirstName + " " + ResidentMiddleName + " " + ResidentLastName; }
           
        }

        [Display(Name = "First Name") Required]
        public string ResidentFirstName { get; set; }

        [Display(Name = "Middle Name") Required]
        public string ResidentMiddleName { get; set; }

        [Display(Name = "Last Name") Required]
        public string ResidentLastName { get; set; }

        [Display(Name = "Gender") Required]
        public string Gender { get; set; }

        [Display(Name = "Age") Required]
        public int Age { get; set; }

        [Display(Name = "Address") Required]
        public string Address { get; set; }

        [Display(Name = "Religion") Required]
        public string Religion { get; set; }

        [Display(Name = "Civil Status") Required]
        public string Status { get; set; }

        [Display(Name = "Occupation") Required]
        public string Occupation { get; set; }

        [Display(Name = "Nationality") Required]
        public string Nationality { get; set; }

        [Display(Name = "Date of Birth") Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Place of Birth") Required]
        public string PlaceofBirth { get; set; }

        [Display(Name = "Contact Number")]
        public string Contactnumber { get; set; }

      
       

            public virtual ResidentRegister Residents { get; set; } 
        }
    }
