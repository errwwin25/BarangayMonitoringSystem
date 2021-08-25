using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BarangayMonitoringSystem.Models;
namespace BarangayMonitoringSystem.ViewModels
{
    public class ClearanceResidentsViewModel
    {

       
            public IEnumerable<ResidentRegister> resident { get; set; }
            public IEnumerable<Blotterreports> incidents { get; set; }
            public IEnumerable<Clearances> documentsclearances { get; set; }
           
        }
    }
