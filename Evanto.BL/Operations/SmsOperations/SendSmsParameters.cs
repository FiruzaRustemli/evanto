using System.ComponentModel.DataAnnotations;

namespace Evanto.BL.Operations.SmsOperations
{
    public class SendSmsInput : OperationParameters
    {
        [Required]
       // [Range(1, 5)]
        public int TypeId { get; set; }

        [Required]
       // [StringLength(160, MinimumLength = 6) ]
        public string Text { get; set; }

        [Required]
       // [StringLength(20, MinimumLength = 6)]
        public string Recipient { get; set; }

    }
    public class SendSmsOutput
    {
        public bool IsSent { get; set; } = false;
    }
}
