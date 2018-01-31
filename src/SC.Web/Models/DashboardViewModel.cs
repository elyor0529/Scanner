using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SC.Web.Models
{
    public class DashboardViewModel
    {

        public long Id { get; set; }

        public string Name { get; set; }


        public long Total { get; set; }

    }

    public class LogFileViewModel
    {

        [Required]
        public long ScannerId { get; set; }

        public IDictionary<long,string> Scanners { get; set; }

        [Required]
        public HttpPostedFileBase LogFile { get; set; }

    }

}