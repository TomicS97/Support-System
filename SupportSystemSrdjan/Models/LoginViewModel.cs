using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupportSystemSrdjan.Models
{
    public partial class LoginViewModel
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
    }
}