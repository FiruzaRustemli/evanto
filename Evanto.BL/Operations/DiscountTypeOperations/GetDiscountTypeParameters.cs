using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.DiscountTypeOperations
{
    public class GetDiscountTypeInput:OperationParameters
    {

    }

    public class GetDiscountTypeOutput
    {
        public List<DiscountTypeDto> DiscountTypes { get; set; } = new List<DiscountTypeDto>();
    }

}
