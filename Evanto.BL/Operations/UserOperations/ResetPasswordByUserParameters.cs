using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class ResetPasswordByUserInput : OperationParameters
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
    public class ResetPasswordByUserOutput
    {

    }
}
