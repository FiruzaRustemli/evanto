using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.ServicePeriodOperations
{
    public class GetServicePeriodInput:OperationParameters
    {

    }

    public class GetServicePeriodOutput
    {
        public List<PeriodDto> Periods { get; set; } = new List<PeriodDto>();
    }

}
