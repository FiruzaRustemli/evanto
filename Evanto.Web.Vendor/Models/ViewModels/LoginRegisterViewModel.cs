using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evanto.Web.Vendor.Models.ViewModels
{
    public class LoginRegisterViewModel
    {
        public LoginRegisterViewModel()
        {
            Register = new RegisterViewModel();
            Login = new LoginViewModel();
        }
        public RegisterViewModel Register { get; set; }
        public LoginViewModel Login { get; set; }
    }
}