using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Admin.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "UserName is requeired")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "UserName is requeired")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
