using Evanto.Web.Vendor.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evanto.Web.Vendor.Models.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
             UserInput = new CreateUserInput();
        }
        [Required]
        public CreateUserInput UserInput { get; set; }
        public string Address { get; set; }
    }
}