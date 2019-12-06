using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SupportSystemSrdjan.Models
{
    public class RolasViewModel
    {
        [DisplayName("Roles")]
        public int RolesID { get; set; }
        [DisplayName("Roles")]
        public string RolesName { get; set; }
    }
}