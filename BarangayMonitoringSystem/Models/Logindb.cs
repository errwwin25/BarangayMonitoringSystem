using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace BarangayMonitoringSystem.Models
{
    public class Logindb
    {
        [Key]
        [Display(Name = "Id")]
        public int UserID { get; set; }

        [Display(Name = "Username") Required]
        public string UserName { get; set; }

        [Display(Name = "Password") Required]
        public string Password { get; set; }
        
    
    }
}