using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.FeedbackStatusOperations
{
    public class GetFeedbackStatusInput:OperationParameters
    {

    }

    public class GetFeedbackStatusOutput
    {
        public List<FeedbackStatusDto> FeedbackStatuses { get; set; }
    }

}
