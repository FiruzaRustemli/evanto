using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Vendor
{
    public class VendorServicePacketVendorDto
    {
        public int Id { get; set; }


        public int VendorId { get; set; }


        public int StatusId { get; set; }


        public int? DiscountCouponId { get; set; }


        public int PaymentId { get; set; }


        public string Description { get; set; }


        public DateTime? CreatedDate { get; set; }


        public DateTime? ActivationDate { get; set; }

        public VendorServicePacketStatusVendorDto VendorServicePacketStatus { get; set; }
    }
}
