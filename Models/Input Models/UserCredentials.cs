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
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsRemember { get; set; }
    }
}
