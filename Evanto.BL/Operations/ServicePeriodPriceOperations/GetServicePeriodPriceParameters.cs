using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.Operations.ServicePeriodPriceOperations
{
    public class GetServicePeriodPriceInput: OperationParameters
    {

    }
    public class GetServicePeriodPriceOutput
    {
        public List<ServicePeriodPricesGroupedVendorDto> ServicePeriodPricesGrouped { get; set; }
    }
}
