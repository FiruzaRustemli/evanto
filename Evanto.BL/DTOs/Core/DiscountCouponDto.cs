using System;
using System.Collections.Generic;

namespace Evanto.BL.DTOs.Core
{
    public class DiscountCouponDto : IDtoBase
    {
         
        public int Id { get; set; }

         
        public int StatusId { get; set; }

         
        public int CouponTypeId { get; set; }

         
        public int DiscountTypeId { get; set; }

         
        public string CouponNumber { get; set; }

         
        public int Quantity { get; set; }

         
        public string Description { get; set; }

         
        public DateTime? CreatedDate { get; set; }

         
        public CouponTypeDto CouponType { get; set; }

         
        public DiscountCouponStatusDto DiscountCouponStatus { get; set; }

         
        public DiscountTypeDto DiscountType { get; set; }

         
        public List<VendorServiceDto> VendorServices { get; set; } = new List<VendorServiceDto>();

         
        public List<VendorServicePacketDto> VendorServicePackets { get; set; } = new List<VendorServicePacketDto>();

        
    }
}