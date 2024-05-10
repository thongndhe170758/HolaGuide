using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Input_Models
{
    public class UserCredentials
    {
        [Required(ErrorMessage = "Email Required!")]
        [EmailAddress(ErrorMessage = "Invalid Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required!")]
        public string Password { get; set; }
    }
}
