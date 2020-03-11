using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Vendor.Models
{
    public class GetVendorServiceInput
    {
        public int? Id { get; set; }
        public int? VendorServicePacketId { get; set; }
        public int? ServicePeriodPriceId { get; set; }
        public int? ServiceId { get; set; }
        public int? VendorId { get; set; }
    }
}
