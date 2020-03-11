using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class VerifyUserAccountInput : OperationParameters
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        [RegularExpression("^[0-9]*$")]
        public string VerificationCode { get; set; }
    }

    public class VerifyUserAccountOutput 
    {

    }
}
