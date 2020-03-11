using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.DiscountCouponOperations
{
    public class GetDiscountCouponInput : OperationParameters
    {
        public string CouponNumber { get; internal set; }
        public int? CouponTypeId { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
        public int? DiscountTypeId { get; internal set; }
        public int? Id { get; internal set; }
        public int? StatusId { get; internal set; }
    }
    public class GetDiscountCouponOutput
    {
        public List<DiscountCouponDto> DiscountCoupons { get; set; }
    }
}
