using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.Feedback.Create;

namespace Evanto.BL.Operations.FeedbackOperations
{
    public class UpdateFeedbackInput : OperationParameters
    {
        public int Id { get; set; }
        public bool SendEmail { get; set; }
        
        public string Email { get; set; }
        [Range(1, int.MaxValue, ErrorMessageResourceName = "TypeIdIsRequired", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        public int StatusId { get; set; }

        
      
    }
    public class UpdateFeedbackOutput
    {
        public string Email { get; set; }
        public bool IsUpdated { get; set; } = false;
    }
}
