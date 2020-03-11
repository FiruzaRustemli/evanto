using System;
using System.Collections.Generic;

namespace Evanto.BL.DTOs.Core
{
    public class CouponTypeDto : IDtoBase
    {
        public int Id { get; set; }

         
        public string Name { get; set; }

         
        public string Description { get; set; }

         
        public DateTime? CreatedDate { get; set; }

         
        public List<DiscountCouponDto> DiscountCoupons { get; set; } = new List<DiscountCouponDto>();
        
    }
}