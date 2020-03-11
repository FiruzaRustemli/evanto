using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evanto.Web.Vendor.Models.ViewModels
{
    public class ProfileViewModel
    {
        public Models.DTOs.VendorDto Vendor { get; set; }
        public Models.DTOs.FileDto File { get; set; }
    }
}