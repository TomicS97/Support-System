using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupportSystemSrdjan.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        [DisplayName("Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Enter the number in: (###) ###-###")]
        public string Phone { get; set; }
        [DisplayName("Roles")]
        public int? RolesID { get; set; }
        [DisplayName("Roles")]
        public string RolesName { get; set; }
        public bool Aktivan { get; set; }


        public List<SelectListItem> Roles { get; set; }
    }
}