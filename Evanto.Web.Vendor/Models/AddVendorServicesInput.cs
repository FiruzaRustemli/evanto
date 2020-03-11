using Evanto.Web.Vendor.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evanto.Web.Vendor.Models
{
    public class AddVendorServicesInput
    {
        public List<VendorServiceDto> VendorServices { get; set; }
        public PaymentDto Payment { get; set; }
        public string CouponNumber { get; set; }
        public int VendorId { get; set; }
    }
}