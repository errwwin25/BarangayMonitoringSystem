using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarangayMonitoringSystem.Models;
using System.ComponentModel.DataAnnotations;
namespace BarangayMonitoringSystem.ViewModels
{
    public class ResidentViewModels
    {
        public ResidentRegister fullname { get; set; }


        public Blotterreports incidents { get; set; }

       

        public Clearances documents { get; set; }

        public SelectList ResidentList { get; set; }
    }
}