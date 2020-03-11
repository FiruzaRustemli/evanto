using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.ServicePeriodPriceOperations
{
    public class GetServicePeriodPriceByAdminInput:OperationParameters
    {

    }

    public class GetServicePeriodPriceByAdminOutput
    {
        public List<ServicePeriodPriceDto> ServicePeriodPrices { get; set; } = new List<ServicePeriodPriceDto>();
    }

}
