﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Vendor.Models.ViewModels
{
    public class ContactInformationViewModel
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
