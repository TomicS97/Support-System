using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SupportSystemSrdjan.Models
{
    public class SectionViewModel
    {
        public int SectionID { get; set; }
        [DisplayName("Status name")]
        public string SectionName { get; set; }
        public string Description { get; set; }
    }
}