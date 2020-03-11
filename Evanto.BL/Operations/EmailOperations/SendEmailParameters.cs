using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.EmailOperations
{
    public class SendEmailInput : OperationParameters
    {
        public string Content { get; set; }
        public string Subject { get; set; }
        public string Recipient { get; set; }
        public EmailType EmailType { get; set; }

    }
    public class SendEmailOutput
    {
        public bool IsSent { get; set; } = false;
    }
}
