using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class ForgotPasswordInput : OperationParameters
    {
        [EmailAddress]
        public string Email  { get; set; }

        [StringLength(20, MinimumLength = 7)]
        public string Phone { get; set; }
    }

    public class ForgotPasswordOutput : OperationParameters
    {

    }
}
