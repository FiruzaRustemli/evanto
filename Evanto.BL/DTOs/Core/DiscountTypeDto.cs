//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/01/20 - 23:27:45
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Evanto.BL.DTOs.Core
{
    public class DiscountTypeDto : IDtoBase
    {
         
        public int Id { get; set; }

         
        public string Name { get; set; }

         
        public string Description { get; set; }

         
        public DateTime? CreatedDate { get; set; }

         
        public List<DiscountCouponDto> DiscountCoupons { get; set; } = new List<DiscountCouponDto>();

        
    }
}