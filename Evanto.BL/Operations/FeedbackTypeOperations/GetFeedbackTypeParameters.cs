using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.FeedbackTypeOperations
{
    public class GetFeedbackTypeInput:OperationParameters
    {

    }

    public class GetFeedbackTypeOutput
    {
        public List<FeedbackTypeDto> FeedbackTypes { get; set; } = new List<FeedbackTypeDto>();
    }

}
