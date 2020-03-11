using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class SendVerificationCodeByUserInput : OperationParameters
    {
        [Required]
        [Range(1,2)]
        public byte VerificationType { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
    public class SendVerificationCodeByUserOutput
    {
        public int test { get; set; } = 1;
    }
}
