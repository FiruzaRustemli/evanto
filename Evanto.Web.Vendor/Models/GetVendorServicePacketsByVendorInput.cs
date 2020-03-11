using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Vendor.Models
{
    public class GetVendorServicePacketByVendorInput
    {
        public int? Id { get; set; }

        public int? VendorId { get; set; }

        public int? StatusId { get; set; }

        public int? DiscountCouponId { get; set; }

        public int? PaymentId { get; set; }

    }
}
