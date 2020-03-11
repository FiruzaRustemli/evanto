using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.FeedbackOperations
{
    public class GetFeedbackInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? TypeId { get; set; }
        public int? StatusId { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
    }
    public class GetFeedbackOutput
    {
        public List<FeedbackDto> Feedbacks { get; set; }
    }
}
