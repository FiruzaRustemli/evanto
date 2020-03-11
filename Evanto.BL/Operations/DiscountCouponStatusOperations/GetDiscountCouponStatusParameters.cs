using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.DiscountCouponStatusOperations
{
    public class GetDiscountCouponStatusInput:OperationParameters
    {

    }

    public class GetDiscountCouponStatusOutput
    {
        public List<DiscountCouponStatusDto> DiscountCouponStatuses { get; set; }
    }

}
