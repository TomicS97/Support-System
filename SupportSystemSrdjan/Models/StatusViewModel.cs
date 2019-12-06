using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SupportSystemSrdjan.Models
{
    public class StatusViewModel
    {
        public int StatusID { get; set; }
        [DisplayName("Status name")]
        public string StatusName { get; set; }
        public string Description { get; set; }

    }
}