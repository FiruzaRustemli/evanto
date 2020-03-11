using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.CouponTypeOperations
{
    public class GetCouponTypeInput:OperationParameters
    {

    }

    public class GetCouponTypeOutput
    {
        public List<CouponTypeDto> CouponTypes { get; set; } = new List<CouponTypeDto>();
    }

}
