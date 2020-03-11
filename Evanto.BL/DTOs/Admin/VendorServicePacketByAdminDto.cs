using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.DTOs.Admin
{
    public class VendorServicePacketByAdminDto
    {
        public int Id { get; set; }


        public int VendorId { get; set; }


        public int StatusId { get; set; }


        public int? DiscountCouponId { get; set; }


        public int? ExpirationDay { get; set; }

        public int? PaymentId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public PaymentAdminDto Payment { get; set; }

        public DateTime? ActivationDate { get; set; }


        public ICollection<VendorServiceByAdminDto> VendorService { get; set; }


        public VendorServicePacketStatusByAdminDto VendorServicePacketStatus { get; set; }
    }
}
