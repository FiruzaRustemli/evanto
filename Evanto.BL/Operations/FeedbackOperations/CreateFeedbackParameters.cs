using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.Feedback.Create;

namespace Evanto.BL.Operations.FeedbackOperations
{
    public class CreateFeedbackInput : OperationParameters
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessageResourceName = "TypeIdIsRequired", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        public int TypeId { get; set; }

        [Required(ErrorMessageResourceName = "EmailIsRequired", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        [MaxLength(30, ErrorMessageResourceName = "EmailMaxLength",ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        [MinLength(5, ErrorMessageResourceName = "EmailMinLength", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        [EmailAddress(ErrorMessageResourceName = "EmailIsNotValid", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "SubjectIsRequired", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        [MaxLength(50, ErrorMessageResourceName = "SubjectMaxLength", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        [MinLength(3, ErrorMessageResourceName = "SubjectMinLength", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        public string Subject { get; set; }

        [Required (ErrorMessageResourceName = "TextIsRequired", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        [MaxLength(200, ErrorMessageResourceName = "TextMaxLength", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        [MinLength(3, ErrorMessageResourceName = "TextMinLength", ErrorMessageResourceType = typeof(CreateFeedbackResource))]
        public string Text { get; set; }
    }
    public class CreateFeedbackOutput
    {
        public bool IsCreated { get; set; } = false;
    }
}
