using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class VerifyEmailInput : OperationParameters
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public bool Status { get; set; }

        
    }

    public class VerifyEmailOutput 
    {
      public bool IsVerified { get; set; }
    }
}
